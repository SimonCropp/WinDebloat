using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using CliWrap.Buffered;

// Edits the machine part of the local Group Policy Object, so that a policy value is written by the
// Group Policy engine rather than by WinDebloat. Used for policy values that the User Choice Protection
// Driver (UCPD.sys) refuses to let other processes write, e.g. HKLM\SOFTWARE\Policies\Microsoft\Dsh.
// Registry.pol format: https://learn.microsoft.com/en-us/previous-versions/windows/desktop/policy/registry-policy-file-format
public static class LocalGroupPolicy
{
    static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "GroupPolicy");
    static string machinePolicyPath = Path.Combine(directory, "Machine", "Registry.pol");
    static string gptIniPath = Path.Combine(directory, "gpt.ini");

    // "PReg"
    const uint signature = 0x67655250;
    const uint fileVersion = 1;

    // Registry client side extension, so the Group Policy engine applies Registry.pol
    const string registryExtension = "{35378EAC-683F-11D2-A89A-00C04FBBCFA2}";

    // Registry client side extension paired with the Administrative Templates (Computers) editor extension
    const string machineExtensionNames = "[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{D02B1F72-3407-48AE-BA88-E8213C6761F1}]";

    const string extensionNamesPrefix = "gPCMachineExtensionNames=";
    const string versionPrefix = "Version=";

    public static async Task SetMachineValue(string key, string valueName, object value, RegistryValueKind kind)
    {
        var entries = File.Exists(machinePolicyPath) ? Parse(File.ReadAllBytes(machinePolicyPath)) : [];
        SetValue(entries, CreateEntry(key, valueName, value, kind));
        Directory.CreateDirectory(Path.GetDirectoryName(machinePolicyPath)!);
        File.WriteAllBytes(machinePolicyPath, Serialize(entries));

        var gptIni = File.Exists(gptIniPath) ? File.ReadAllText(gptIniPath) : "";
        File.WriteAllText(gptIniPath, UpdateGptIni(gptIni));

        await Refresh();
    }

    static async Task Refresh()
    {
        Log.Information("Executing: gpupdate /target:computer /force");
        var result = await Cli.Wrap("gpupdate")
            .WithArguments(["/target:computer", "/force"])
            .WithValidation(CommandResultValidation.None)
            .ExecuteBufferedAsync();

        if (result.ExitCode != 0)
        {
            Log.Warning(
                "gpupdate failed with exit code {ExitCode}. Output: {Output} Error: {Error}",
                result.ExitCode,
                result.StandardOutput,
                result.StandardError);
        }
    }

    public static List<PolicyEntry> Parse(byte[] bytes)
    {
        var entries = new List<PolicyEntry>();
        using var reader = new BinaryReader(new MemoryStream(bytes));
        if (bytes.Length < 8 ||
            reader.ReadUInt32() != signature ||
            reader.ReadUInt32() != fileVersion)
        {
            throw new("Registry.pol has an unexpected header");
        }

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            Expect(reader, '[');
            var key = ReadString(reader);
            Expect(reader, ';');
            var valueName = ReadString(reader);
            Expect(reader, ';');
            var type = reader.ReadUInt32();
            Expect(reader, ';');
            var size = reader.ReadUInt32();
            Expect(reader, ';');
            var data = reader.ReadBytes((int) size);
            Expect(reader, ']');
            entries.Add(new(key, valueName, type, data));
        }

        return entries;
    }

    public static byte[] Serialize(IEnumerable<PolicyEntry> entries)
    {
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);
        writer.Write(signature);
        writer.Write(fileVersion);
        foreach (var entry in entries)
        {
            WriteChar(writer, '[');
            WriteString(writer, entry.Key);
            WriteChar(writer, ';');
            WriteString(writer, entry.ValueName);
            WriteChar(writer, ';');
            writer.Write(entry.Type);
            WriteChar(writer, ';');
            writer.Write((uint) entry.Data.Length);
            WriteChar(writer, ';');
            writer.Write(entry.Data);
            WriteChar(writer, ']');
        }

        writer.Flush();
        return stream.ToArray();
    }

    // Replaces an existing entry for the same key and value name, or appends one. Also drops any
    // "**del.<value name>" instruction for the value, since that would delete it again.
    public static void SetValue(List<PolicyEntry> entries, PolicyEntry entry)
    {
        entries.RemoveAll(_ =>
            string.Equals(_.Key, entry.Key, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_.ValueName, $"**del.{entry.ValueName}", StringComparison.OrdinalIgnoreCase));

        var index = entries.FindIndex(_ =>
            string.Equals(_.Key, entry.Key, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(_.ValueName, entry.ValueName, StringComparison.OrdinalIgnoreCase));
        if (index == -1)
        {
            entries.Add(entry);
        }
        else
        {
            entries[index] = entry;
        }
    }

    // Makes sure the Registry client side extension is listed, and bumps the machine version (the low
    // 16 bits of Version) so the Group Policy engine sees the change.
    public static string UpdateGptIni(string content)
    {
        var lines = content
            .Split('\n')
            .Select(_ => _.TrimEnd('\r'))
            .Where(_ => _.Trim().Length > 0)
            .ToList();

        var generalIndex = lines.FindIndex(_ => _.Trim().Equals("[General]", StringComparison.OrdinalIgnoreCase));
        if (generalIndex == -1)
        {
            lines.Insert(0, "[General]");
            generalIndex = 0;
        }

        var extensionIndex = lines.FindIndex(_ => _.StartsWith(extensionNamesPrefix, StringComparison.OrdinalIgnoreCase));
        if (extensionIndex == -1)
        {
            lines.Insert(generalIndex + 1, extensionNamesPrefix + machineExtensionNames);
        }
        else if (!lines[extensionIndex].Contains(registryExtension, StringComparison.OrdinalIgnoreCase))
        {
            var groups = Regex
                .Matches(lines[extensionIndex][extensionNamesPrefix.Length..], @"\[[^\]]*\]")
                .Select(_ => _.Value)
                .Append(machineExtensionNames)
                .Order(StringComparer.OrdinalIgnoreCase);
            lines[extensionIndex] = extensionNamesPrefix + string.Concat(groups);
        }

        var versionIndex = lines.FindIndex(_ => _.StartsWith(versionPrefix, StringComparison.OrdinalIgnoreCase));
        if (versionIndex == -1)
        {
            lines.Insert(generalIndex + 1, $"{versionPrefix}1");
        }
        else
        {
            var version = uint.Parse(lines[versionIndex][versionPrefix.Length..].Trim(), CultureInfo.InvariantCulture);
            var userVersion = version & 0xFFFF0000;
            var machineVersion = (version + 1) & 0xFFFF;
            lines[versionIndex] = $"{versionPrefix}{userVersion | machineVersion}";
        }

        return string.Join("\r\n", lines) + "\r\n";
    }

    public static PolicyEntry CreateEntry(string key, string valueName, object value, RegistryValueKind kind) =>
        new(key, valueName, (uint) kind, ToBytes(value, kind));

    static byte[] ToBytes(object value, RegistryValueKind kind) =>
        kind switch
        {
            RegistryValueKind.DWord => BitConverter.GetBytes(Convert.ToInt32(value, CultureInfo.InvariantCulture)),
            RegistryValueKind.QWord => BitConverter.GetBytes(Convert.ToInt64(value, CultureInfo.InvariantCulture)),
            RegistryValueKind.String or RegistryValueKind.ExpandString => Encoding.Unicode.GetBytes($"{value}\0"),
            RegistryValueKind.Binary => (byte[]) value,
            _ => throw new NotSupportedException($"Registry value kind {kind} is not supported in Registry.pol")
        };

    static void Expect(BinaryReader reader, char expected)
    {
        var ch = ReadChar(reader);
        if (ch != expected)
        {
            throw new($"Registry.pol is malformed. Expected '{expected}' but found '{ch}' at {reader.BaseStream.Position - 2}");
        }
    }

    static char ReadChar(BinaryReader reader) =>
        (char) reader.ReadUInt16();

    static string ReadString(BinaryReader reader)
    {
        var builder = new StringBuilder();
        while (true)
        {
            var ch = ReadChar(reader);
            if (ch == '\0')
            {
                return builder.ToString();
            }

            builder.Append(ch);
        }
    }

    static void WriteChar(BinaryWriter writer, char ch) =>
        writer.Write((ushort) ch);

    static void WriteString(BinaryWriter writer, string value)
    {
        foreach (var ch in value)
        {
            WriteChar(writer, ch);
        }

        WriteChar(writer, '\0');
    }
}

// Type is the raw Win32 registry type (REG_NONE is 0), since RegistryValueKind maps REG_NONE to -1.
public record PolicyEntry(string Key, string ValueName, uint Type, byte[] Data);
