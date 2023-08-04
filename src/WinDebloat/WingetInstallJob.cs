public record WingetInstallJob(
    string Name,
    string? Notes = null):
    IJob
{
    public string Description => $"Installing {Name}";

    public Task Run()
    {
        return  WinGet.InstallByName(Name);
    }
}