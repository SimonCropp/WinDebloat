public record InstallJob(
    string Name,
    string? Notes = null):
    IJob;