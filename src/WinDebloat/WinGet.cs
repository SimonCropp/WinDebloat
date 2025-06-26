public static class WinGet
{
    public static string ExpectedPath = Path.Combine(
        Environment.GetEnvironmentVariable("LOCALAPPDATA")!,
        @"Microsoft\WindowsApps\winget.exe");

    public static Version MinVersion { get; } = new(1, 10, 340);

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

    public static Task InstallByName(string name)
    {
        var arguments = $"install --name \"{name}\" --disable-interactivity --exact --no-upgrade --silent --accept-source-agreements --accept-package-agreements";
        return InnerInstall(arguments);
    }

    public static Task InstallById(string id)
    {
        var arguments = $"install --id \"{id}\" --disable-interactivity --exact --no-upgrade --silent --accept-source-agreements --accept-package-agreements";
        return InnerInstall(arguments);
    }

    static async Task InnerInstall(string arguments)
    {
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

    public static Task UninstallByName(string name, bool partialMatch)
    {
        string arguments;
        if (partialMatch)
        {
            arguments = $"uninstall \"{name}\" --disable-interactivity --silent --accept-source-agreements --all-versions";
        }
        else
        {
            arguments = $"uninstall --name \"{name}\" --disable-interactivity --exact --silent --accept-source-agreements --all-versions";
        }

        return InnerUninstall(arguments);
    }

    public static Task UninstallById(string id)
    {
        var arguments = $"uninstall --id \"{id}\" --disable-interactivity --exact --silent --accept-source-agreements --all-versions";
        return InnerUninstall(arguments);
    }

    static async Task InnerUninstall(string arguments)
    {
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

    public static async Task<List<(string name, string id)>> List()
    {
        var result = await Run("list --accept-source-agreements");

        if (result.ExitCode != 0)
        {
            Throw("list", result);
        }

        var list = new List<(string name, string id)>();
        foreach (var line in result.Output.Skip(2))
        {
            if (line.Length >= 81)
            {
                var name = line[..39].Trim();
                var id = line[40..81].Trim();
                list.Add((name, id));
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

        return SafeVersion.Parse(result.Output[0]);
    }

    [DoesNotReturn]
    static void Throw(string arguments, RunResult result) =>
        throw new(
            $"""
             Error. Command line: winget {arguments}.
               ExitCode: {result.ExitCode}
               Output: {string.Join('\n', result.Output)}
               Error: {string.Join('\n', result.Error)}
             """);

    static async Task<RunResult> Run(string arguments)
    {
        Log.Debug("Executing: winget {Arguments}", arguments);
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