[TestFixture]
public class Extra
{
    //https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/database-file-operations/troubleshoot-os-4kb-disk-sector-size
    static void ForcedPhysicalSectorSizeInBytes() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\stornvme\Parameters\Device",
            "ForcedPhysicalSectorSizeInBytes",
            new[] {"* 4095"},
            RegistryValueKind.MultiString);
}