static class Logging
{
    public static string LogsDirectory { get; } = Path.Combine(AssemblyLocation.CurrentDirectory, "logs");

    public static void Init()
    {
        Console.Write($"Logs Directory: {LogsDirectory}");
        Directory.CreateDirectory(LogsDirectory);
        var configuration = new LoggerConfiguration();
        configuration.MinimumLevel.Information();
        configuration.WriteTo.File(
            Path.Combine(LogsDirectory, "log.txt"),
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: 1000000, //1mb
            retainedFileCountLimit: 10);
        configuration.WriteTo.Console();
        Log.Logger = configuration.CreateLogger();
    }
}