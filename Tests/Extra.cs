[TestFixture]
public class Extra
{
    [Test]
    public async Task Run()
    {
        ForcedPhysicalSectorSizeInBytes();
        InstallDiffEngineTray();

        //await Install("Microsoft.SQLServerManagementStudio");
        await WinGet.Install("ScooterSoftware.BeyondCompare4");

        DisableService("HpTouchpointAnalyticsService");
        DisableService("HPAppHelperCap");
        DisableService("HPDiagsCap");
        DisableService("HPSysInfoCap");
        DisableService("hpsvcsscan");
        DisableService("HotKeyServiceDSU");
        await WinGet.Uninstall("HP Notifications");
        await WinGet.Uninstall("HP Documentation");
        await WinGet.Uninstall("HPHelp");
        DisableService("Spooler");
        //await Upgrade();
    }

    //https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/database-file-operations/troubleshoot-os-4kb-disk-sector-size
    static void ForcedPhysicalSectorSizeInBytes() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\stornvme\Parameters\Device",
            "ForcedPhysicalSectorSizeInBytes",
            new[]{ "* 4095"},
            RegistryValueKind.MultiString);

    static void InstallDiffEngineTray() =>
        Process.Start("dotnet", "tool install -g DiffEngineTray");

    static void DisableService(string serviceName)
    {
        using (var sc = new ServiceController(serviceName))
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
            }
        }

        using (var m = new ManagementObject($"Win32_Service.Name=\"{serviceName}\""))
        {
            m.InvokeMethod("ChangeStartMode", new object[] {"Disabled"});
        }
    }
}