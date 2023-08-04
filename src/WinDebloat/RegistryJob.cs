public record RegistryJob(
    string Key,
    string Name,
    object Value,
    RegistryValueKind Kind = RegistryValueKind.DWord,
    string? Notes = null):
    IJob
{
    public string Description => $@"Setting registry {Key}\{Name} to {Value} ({Kind})";

    public void Assert()
    {
        var actual = Registry.GetValue(Key, Name, null);

        if (Value.Equals(actual))
        {
            return;
        }

        throw new($@"{Key}\{Name} is {actual} when it should be {Value}");
    }

    public void Run()
    {
        Registry.SetValue(Key, Name, Value, Kind);
    }
}