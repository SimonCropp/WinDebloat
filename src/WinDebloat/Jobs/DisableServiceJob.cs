public record DisableServiceJob(
    string Name,
    string? Notes = null):
    IJob;