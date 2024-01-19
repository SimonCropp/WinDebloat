public record DeleteTaskJob(
    string Name,
    string Path,
    string? Notes = null) :
    IJob;