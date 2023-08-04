public record RegistryJob(
    string Key,
    string Name,
    object Value,
    RegistryValueKind Kind = RegistryValueKind.DWord,
    string? Notes = null) :
    IJob
{
    public string Description => $@"Setting registry {Key}\{Name} to {Value} ({Kind})";
}