public static class WinGet
{
    public static string ExpectedPath = Path.Combine(
        Environment.GetEnvironmentVariable("LOCALAPPDATA")!,
        @"Microsoft\WindowsApps\winget.exe");

    public static Version MinVersion { get; } = new(1, 5, 2201);

    public static void EnsureInstalled()
    {
        if (File.Exists(ExpectedPath))
        {
            return;
        }

        throw new WinGetNotInstalledException();
    }

    public static async Task EnsureVersion()
    {
        var version = await GetVersion();

        if (version >= MinVersion)
        {
            return;
        }

        throw new WinGetVersionNotMetException(version);
    }

    public static async Task Install(string name)
    {
        var arguments = GetInstallArguments(name);
        var result = await Run(arguments);

        if (result.ExitCode == 0)
        {
            return;
        }

        if (result.Output.Any(_ => _.Contains("already installed")))
        {
            return;
        }

        Throw(arguments, result);
    }

    public static string GetInstallArguments(string name) =>
        $"install --name \"{name}\" --disable-interactivity --exact --no-upgrade --silent --accept-source-agreements --accept-package-agreements";

    public static async Task Uninstall(string name)
    {
        var arguments = $"uninstall --name \"{name}\" --disable-interactivity --exact --silent --accept-source-agreements";
        var result = await Run(arguments);

        if (result.ExitCode == 0)
        {
            return;
        }

        if (result.Output.Any(_ => _.Contains("No installed package found matching input criteria")))
        {
            return;
        }

        Throw(arguments, result);
    }

    public static async Task<List<string>> List()
    {
        var result = await Run("list --accept-source-agreements");

        if (result.ExitCode != 0)
        {
            Throw("list", result);
        }

        var list = new List<string>();
        foreach (var line in result.Output.Skip(2))
        {
            if (line.Length > 35)
            {
                list.Add(line[..35].Trim());
            }
        }

        return list;
    }

    public static async Task ResetSources()
    {
        var arguments = "source reset --force";
        var result = await Run(arguments);

        if (result.ExitCode != 0)
        {
            Throw(arguments, result);
        }
    }

    public static async Task<Version> GetVersion()
    {
        var arguments = "--version";
        var result = await Run(arguments);

        if (result.ExitCode != 0)
        {
            Throw(arguments, result);
        }

        return Version.Parse(result.Output[0][1..]);
    }

    static void Throw(string arguments, RunResult result)
    {
        throw new(
            $"""
             Error. Command line: winget {arguments}.
               ExitCode: {result.ExitCode}
               Output: {string.Join('\n', result.Output)}
               Error: {string.Join('\n', result.Error)}
             """);
    }

    static async Task<RunResult> Run(string arguments)
    {
        Log.Debug($"Executing: winget {arguments}");
        var error = new List<string>();
        var output = new List<string>();

        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_ => AppendLine(output, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_ => AppendLine(error, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        return new(commandResult.ExitCode, output, error);
    }

    static void AppendLine(List<string> list, string line)
    {
        var data = line.Trim();
        if (data.Length > 1)
        {
            list.Add(data);
        }
    }
}