public static class WinGet
{
    public static Task InstallByName(string name) =>
        Install($"--name \"{name}\"");

    public static Task InstallById(string id) =>
        Install($"--id \"{id}\"");

    static async Task Install(string match)
    {
        var arguments = $"install {match} --disable-interactivity --exact --no-upgrade --silent --accept-source-agreements --accept-package-agreements";
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

    public static Task UninstallById(string id) =>
        Uninstall($"--id \"{id}\"");

    public static Task UninstallByName(string name) =>
        Uninstall($"--name \"{name}\"");

    static async Task Uninstall(string match)
    {
        var arguments = $"uninstall {match} --disable-interactivity --exact --silent --accept-source-agreements";
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

    public static async Task<List<Package>> List()
    {
        var result = await Run("list");

        if (result.ExitCode != 0)
        {
            Throw("list", result);
        }

        var list = new List<Package>();
        foreach (var line in result.Output.Skip(2))
        {
            if (line.Length > 35)
            {
                list.Add(new(
                    line[..35].TrimEnd(),
                    line[36..73].TrimEnd()));
            }
        }

        return list;
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

    public static async Task<RunResult> Run(string arguments)
    {
        Log.Information($"Executing: winget {arguments}");
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
        if (data is {Length: > 1})
        {
            list.Add(data);
        }
    }
}