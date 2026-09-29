[NotInParallel]
public class RegistryTests
{
    [Test]
    public async Task NonExistingParent()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        try
        {
            var registryJob = new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\WinDebloat\Child",
                "TaskbarDa",
                0,
                1,
                "TaskbarDa");
            Program.HandleRegistry(registryJob);

            using var key = Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")!;

            await Assert.That(key.GetValue("TaskbarDa")).IsEqualTo(0);
        }
        finally
        {
            Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);
        }
    }

    [Test]
    public async Task DeleteValue()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        try
        {
            using (var seed = Registry.CurrentUser.CreateSubKey(@"Software\WinDebloat\Child"))
            {
                seed.SetValue("Allow Telemetry", 0, RegistryValueKind.DWord);
                seed.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
            }

            var job = new DeleteRegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\WinDebloat\Child",
                "Allow Telemetry",
                "Allow Telemetry");
            Program.HandleRegistry(job);

            using var key = Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")!;

            // the stale spaced value is gone, the real one is untouched
            await Assert.That(key.GetValue("Allow Telemetry")).IsNull();
            await Assert.That(key.GetValue("AllowTelemetry")).IsEqualTo(0);

            // running again when the value is already absent is a no-op
            Program.HandleRegistry(job);
            await Assert.That(key.GetValue("Allow Telemetry")).IsNull();
        }
        finally
        {
            Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);
        }
    }

    [Test]
    public async Task DeleteValueWithNonExistingParent()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        var job = new DeleteRegistryValueJob(
            RegistryHive.CurrentUser,
            @"Software\WinDebloat\Child",
            "Allow Telemetry",
            "Allow Telemetry");
        Program.HandleRegistry(job);

        // the key must not be created as a side effect of the delete
        await Assert.That(Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")).IsNull();
    }

    [Test]
    public async Task DeleteValuesByPrefix()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        try
        {
            using (var seed = Registry.CurrentUser.CreateSubKey(@"Software\WinDebloat\Child"))
            {
                seed.SetValue("MicrosoftEdgeAutoLaunch_6B0DB9F2", "msedge.exe", RegistryValueKind.String);
                seed.SetValue("MicrosoftEdgeAutoLaunch_A1B2C3D4", "msedge.exe", RegistryValueKind.String);
                seed.SetValue("OneDrive", "OneDrive.exe", RegistryValueKind.String);
            }

            var job = new DeleteRegistryValuesByPrefixJob(
                RegistryHive.CurrentUser,
                @"Software\WinDebloat\Child",
                "MicrosoftEdgeAutoLaunch_",
                "MicrosoftEdgeAutoLaunch");
            Program.HandleRegistry(job);

            using var key = Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")!;

            // all matching values are gone, others are untouched
            await Assert.That(key.GetValueNames()).IsEquivalentTo(["OneDrive"]);

            // running again when nothing matches is a no-op
            Program.HandleRegistry(job);
            await Assert.That(key.GetValueNames()).IsEquivalentTo(["OneDrive"]);
        }
        finally
        {
            Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);
        }
    }

    [Test]
    public async Task DeleteValuesByPrefixWithNonExistingParent()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        var job = new DeleteRegistryValuesByPrefixJob(
            RegistryHive.CurrentUser,
            @"Software\WinDebloat\Child",
            "MicrosoftEdgeAutoLaunch_",
            "MicrosoftEdgeAutoLaunch");
        Program.HandleRegistry(job);

        // the key must not be created as a side effect of the delete
        await Assert.That(Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")).IsNull();
    }
}