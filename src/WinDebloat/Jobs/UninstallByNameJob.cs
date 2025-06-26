public record UninstallByNameJob(
    string Name,
    string? Notes = null):
    IJob;