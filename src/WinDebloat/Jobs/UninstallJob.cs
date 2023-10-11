public record UninstallJob(
    string Name,
    string? Notes = null,
    bool PartialMatch = false):
    IJob;