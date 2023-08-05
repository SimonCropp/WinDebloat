public record RegistryJob(
    string Key,
    string Name,
    object ApplyValue,
    object RevertValue,
    RegistryValueKind Kind = RegistryValueKind.DWord,
    string? Notes = null) :
    IJob;