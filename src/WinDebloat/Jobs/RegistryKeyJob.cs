public record RegistryKeyJob(
    RegistryHive Hive,
    string Key,
    string? Notes = null,
    bool Invert = false) :
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

    public string Name => Key.Split('\\').Last();
}