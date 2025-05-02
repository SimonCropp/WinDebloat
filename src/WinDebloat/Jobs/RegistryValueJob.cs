public record RegistryValueJob(
    RegistryHive Hive,
    string Key,
    string Name,
    object ApplyValue,
    object? RevertValue,
    RegistryValueKind Kind = RegistryValueKind.DWord,
    string? Notes = null) :
    IJob
{
    public string ShortKey =>
        Hive switch
        {
            RegistryHive.ClassesRoot => $@"HKCR\{Key}",
            RegistryHive.CurrentUser => $@"HKCU\{Key}",
            RegistryHive.LocalMachine => $@"HKLM\{Key}",
            RegistryHive.Users => $@"HKU\{Key}",
            RegistryHive.CurrentConfig => $@"HKCC\{Key}",
            _ => throw new ArgumentOutOfRangeException()
        };
}