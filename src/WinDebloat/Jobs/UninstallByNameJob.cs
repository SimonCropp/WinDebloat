public record UninstallByNameJob(
    string Name,
    string? Notes = null,
    bool PartialMatch = false):
    IJob;