[TestFixture]
public class RegistryTests
{
    [Test]
    public void NonExistingParent()
    {
        Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);

        try
        {
            var registryJob = new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\WinDebloat\Child",
                "TaskbarDa",
                0,
                1);
            Program.HandleRegistry(registryJob);

            using var key = Registry.CurrentUser.OpenSubKey(@"Software\WinDebloat\Child")!;

            AreEqual(0, key.GetValue("TaskbarDa"));
        }
        finally
        {
            Registry.CurrentUser.DeleteSubKeyTree(@"Software\WinDebloat", false);
        }
    }
}