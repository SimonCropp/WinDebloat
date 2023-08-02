using CliWrap;

public static class WinGet
{
    public static Task<RunResult> Install(string name)
    {
        var list = Run($"install --name \"{name}\" --disable-interactivity --exact --no-upgrade --accept-source-agreements --accept-package-agreements");
        return list;
    }

    public static Task<RunResult> Uninstall(string name)
    {
        var list = Run($"uninstall --name \"{name}\" --disable-interactivity --exact");
        return list;
    }

    public static async Task<List<string>> List()
    {
        var result = await Run("list");

        if (result.ExitCode != 0)
        {
            Throw("list", result);
        }

        var list = new List<string>();
        foreach (var line in result.Output.Skip(2))
        {
            if (line.Length > 35)
            {
                list.Add(line[..35].TrimEnd());
            }
        }

        return list;
    }

    static void Throw(string arguments, RunResult result)
    {
        throw new($"""
                   Error. Command line: winget {arguments}.
                     ExitCode: {result.ExitCode}
                     Output: {string.Join('\n', result.Output)}
                     Error: {string.Join('\n', result.Error)}
                   """);
    }

    public static async Task<RunResult> Run(string arguments)
    {
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

    private static void AppendLine(List<string> list, string line)
    {
        var data = line.Trim();
        if (data is {Length: > 1})
        {
            list.Add(data);
        }
    }
}

public record RunResult(int ExitCode, List<string> Output, List<string> Error);
