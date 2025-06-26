public record InstallByNameJob(
    string Name,
    string? Notes = null):
    IJob;