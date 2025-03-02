public record EnvironmentVariableJob(
    string Name,
    string Key,
    string? Value,
    string? Notes = null):
    IJob;