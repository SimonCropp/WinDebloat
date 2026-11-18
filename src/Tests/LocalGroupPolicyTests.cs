public class LocalGroupPolicyTests
{
    // A Registry.pol written by Windows: a single key-only entry for
    // Software\Microsoft\Windows\CurrentVersion\Policies\Explorer (empty value name, REG_NONE, no data)
    const string windowsFile =
        "50526567010000005b0053006f006600740077006100720065005c004d006900630072006f0073006f00660074005c00570069006e0064006f00770073005c00430075007200720065006e007400560065007200730069006f006e005c0050006f006c00690063006900650073005c004500780070006c006f0072006500720000003b0000003b00000000003b00000000003b005d00";

    [Test]
    public async Task ParseWindowsFile()
    {
        var entries = LocalGroupPolicy.Parse(Convert.FromHexString(windowsFile));

        await Assert.That(entries.Count).IsEqualTo(1);
        var entry = entries[0];
        await Assert.That(entry.Key).IsEqualTo(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
        await Assert.That(entry.ValueName).IsEqualTo("");
        await Assert.That(entry.Type).IsEqualTo(0u);
        await Assert.That(entry.Data.Length).IsEqualTo(0);
    }

    [Test]
    public async Task RoundTripWindowsFile()
    {
        var entries = LocalGroupPolicy.Parse(Convert.FromHexString(windowsFile));

        var bytes = LocalGroupPolicy.Serialize(entries);

        await Assert.That(Convert.ToHexStringLower(bytes)).IsEqualTo(windowsFile);
    }

    [Test]
    public async Task AppendDword()
    {
        var entries = LocalGroupPolicy.Parse(Convert.FromHexString(windowsFile));

        LocalGroupPolicy.SetValue(
            entries,
            LocalGroupPolicy.CreateEntry(@"Software\Policies\Microsoft\Dsh", "AllowNewsAndInterests", 0, RegistryValueKind.DWord));

        // [key\0;value\0;REG_DWORD;4;00000000]
        var expected = windowsFile +
                       Utf16("[") +
                       Utf16(@"Software\Policies\Microsoft\Dsh") + "0000" +
                       Utf16(";") +
                       Utf16("AllowNewsAndInterests") + "0000" +
                       Utf16(";") +
                       "04000000" +
                       Utf16(";") +
                       "04000000" +
                       Utf16(";") +
                       "00000000" +
                       Utf16("]");
        await Assert.That(Convert.ToHexStringLower(LocalGroupPolicy.Serialize(entries))).IsEqualTo(expected);
    }

    [Test]
    public async Task ReplaceExistingAndDropDelete()
    {
        List<PolicyEntry> entries =
        [
            LocalGroupPolicy.CreateEntry(@"Software\Policies\Microsoft\Dsh", "AllowNewsAndInterests", 1, RegistryValueKind.DWord),
            LocalGroupPolicy.CreateEntry(@"Software\Policies\Microsoft\Dsh", "**del.AllowNewsAndInterests", " ", RegistryValueKind.String),
            LocalGroupPolicy.CreateEntry(@"Software\Policies\Microsoft\Other", "AllowNewsAndInterests", 1, RegistryValueKind.DWord)
        ];

        LocalGroupPolicy.SetValue(
            entries,
            LocalGroupPolicy.CreateEntry(@"SOFTWARE\Policies\Microsoft\Dsh", "allownewsandinterests", 0, RegistryValueKind.DWord));

        await Assert.That(entries.Count).IsEqualTo(2);
        await Assert.That(entries[0].Key).IsEqualTo(@"SOFTWARE\Policies\Microsoft\Dsh");
        await Assert.That(Convert.ToHexStringLower(entries[0].Data)).IsEqualTo("00000000");
        await Assert.That(entries[1].Key).IsEqualTo(@"Software\Policies\Microsoft\Other");
    }

    [Test]
    public async Task StringEntry()
    {
        var entry = LocalGroupPolicy.CreateEntry("Key", "Name", "abc", RegistryValueKind.String);

        await Assert.That(entry.Type).IsEqualTo(1u);
        await Assert.That(Convert.ToHexStringLower(entry.Data)).IsEqualTo(Utf16("abc") + "0000");
    }

    [Test]
    public async Task GptIniWithRegistryExtension()
    {
        // As written by Windows, including the trailing space
        var content = "[General]\r\ngPCMachineExtensionNames=[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{3D271CFC-2BC6-4AC2-B633-3BDFF5BDAB2A}] \r\nVersion=4\r\n";

        var result = LocalGroupPolicy.UpdateGptIni(content);

        await Assert.That(result).IsEqualTo("[General]\r\ngPCMachineExtensionNames=[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{3D271CFC-2BC6-4AC2-B633-3BDFF5BDAB2A}] \r\nVersion=5\r\n");
    }

    [Test]
    public async Task GptIniMissing()
    {
        var result = LocalGroupPolicy.UpdateGptIni("");

        await Assert.That(result).IsEqualTo("[General]\r\nVersion=1\r\ngPCMachineExtensionNames=[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{D02B1F72-3407-48AE-BA88-E8213C6761F1}]\r\n");
    }

    [Test]
    public async Task GptIniWithOtherExtension()
    {
        var content = "[General]\nVersion=2\ngPCMachineExtensionNames=[{827D319E-6EAC-11D2-A4EA-00C04F79F83A}{803E14A0-B4FB-11D0-A0D0-00A0C90F574B}]\n";

        var result = LocalGroupPolicy.UpdateGptIni(content);

        await Assert.That(result).IsEqualTo("[General]\r\nVersion=3\r\ngPCMachineExtensionNames=[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{D02B1F72-3407-48AE-BA88-E8213C6761F1}][{827D319E-6EAC-11D2-A4EA-00C04F79F83A}{803E14A0-B4FB-11D0-A0D0-00A0C90F574B}]\r\n");
    }

    [Test]
    public async Task GptIniKeepsUserVersion()
    {
        // user version 1 (high 16 bits), machine version 4 (low 16 bits)
        var content = "[General]\r\ngPCMachineExtensionNames=[{35378EAC-683F-11D2-A89A-00C04FBBCFA2}{D02B1F72-3407-48AE-BA88-E8213C6761F1}]\r\nVersion=65540\r\n";

        var result = LocalGroupPolicy.UpdateGptIni(content);

        await Assert.That(result).Contains("Version=65541\r\n");
    }

    static string Utf16(string value) =>
        Convert.ToHexStringLower(Encoding.Unicode.GetBytes(value));
}
