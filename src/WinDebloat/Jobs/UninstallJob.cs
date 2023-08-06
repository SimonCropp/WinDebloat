public record UninstallJob(
    string Name,
    string? Notes = null):
    IJob;