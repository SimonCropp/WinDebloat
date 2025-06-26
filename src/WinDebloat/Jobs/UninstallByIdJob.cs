public record UninstallByIdJob(
    string Name,
    string? Notes = null):
    IJob;