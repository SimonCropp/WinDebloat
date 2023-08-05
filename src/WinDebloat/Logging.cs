static class Logging
{
    public static void Init()
    {
        var directory = Path.Combine(AssemblyLocation.CurrentDirectory, "logs");
        Console.WriteLine($"Logs Directory: {directory}");
        Directory.CreateDirectory(directory);
        var configuration = new LoggerConfiguration();
        configuration.MinimumLevel.Information();
        configuration.WriteTo.File(
            Path.Combine(directory, "log.txt"),
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: 1000000, //1mb
            retainedFileCountLimit: 10);
        configuration.WriteTo.Console();
        Log.Logger = configuration.CreateLogger();
    }
}