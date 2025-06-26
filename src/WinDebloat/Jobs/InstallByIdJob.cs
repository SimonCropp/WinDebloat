public record InstallByIdJob(
    string Name,
    string? Notes = null):
    IJob;