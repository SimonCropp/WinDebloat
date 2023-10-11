public record RegistryKeyJob(
    string Key,
    string? Notes = null) :
    IJob
{
    public string ShortKey =>
        Key
            .Replace("HKEY_LOCAL_MACHINE", "HKLM")
            .Replace("HKEY_CURRENT_CONFIG", "HKCC")
            .Replace("HKEY_CLASSES_ROOT", "HKCR")
            .Replace("HKEY_CURRENT_USER", "HKCU")
            .Replace("HKEY_USERS", "HKU");

    public string Name => Key.Split('\\').Last();
}