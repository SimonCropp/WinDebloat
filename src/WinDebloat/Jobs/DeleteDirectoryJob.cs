public record DeleteDirectoryJob(
    string Path,
    string Name,
    string? Notes = null) :
    IJob
{
    public string ExpandedPath => Environment.ExpandEnvironmentVariables(Path);
}
