public static class WinGetRunner
{
    public static (int ExitCode, List<string> output, List<string> error) Install(string id)
    {
        var list = Run(
            $"install --id {id} --disable-interactivity --exact --no-upgrade  --accept-source-agreements --accept-package-agreements",
            "already installed");
        return list;
    }
    // public static List<string> Uninstall(string id)
    // {
    //     //var arguments = $"uninstall --name \"{name}\" --disable-interactivity --exact";
    //     var list = Run(
    //         $"uninstall --id {id} --disable-interactivity --exact --no-upgrade  --accept-source-agreements --accept-package-agreements",
    //         "already installed");
    //     return list;
    // }

    public static (int ExitCode, List<string> output, List<string> error) Run(string arguments, string successText)
    {
        var error = new List<string>();
        var output = new List<string>();
        using var process = new Process
        {
            StartInfo = new()
            {
                FileName = "winget",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        process.OutputDataReceived += (_, args) => AddLine(args, output);
        process.BeginOutputReadLine();
        process.ErrorDataReceived += (_, args) => AddLine(args, error);
        process.BeginErrorReadLine();
        if (!process.DoubleWaitForExit())
        {
            throw new($"""
                       Process timed out. Command line: winget {arguments}.
                       Output: {string.Join('\n', output)}
                       Error: {string.Join('\n', error)}
                       """);
        }

        return (process.ExitCode, output, error);
    }

    static void AddLine(DataReceivedEventArgs args, List<string> list)
    {
        var data = args.Data?.Trim();
        if (data is {Length: > 1})
        {
            list.Add(data);
        }
    }

    //To work around https://github.com/dotnet/runtime/issues/27128
    static bool DoubleWaitForExit(this Process process)
    {
        var result = process.WaitForExit(60000);
        if (result)
        {
            process.WaitForExit();
        }
        return result;
    }
}

public enum InstallResult
{
}
