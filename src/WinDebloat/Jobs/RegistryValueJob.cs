public record RegistryValueJob(
    RegistryHive Hive,
    string Key,
    string KeyName,
    object ApplyValue,
    object? RevertValue,
    string Name,
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