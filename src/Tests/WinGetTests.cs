#if DEBUG
[TestFixture]
public class WinGetTests
{
    string name = "GitHub CLI";
    string id = "GitHub.cli";

    [Test]
    public async Task AlreadyInstalled()
    {
        await WinGet.Install(name);
        await WinGet.Install(name);
    }

    [Test]
    public async Task AlreadyUninstalled()
    {
        await WinGet.Uninstall(name, false);
        await WinGet.Uninstall(name, false);
    }

    [Test]
    public async Task Install()
    {
        await WinGet.Install(name);
        var list = await WinGet.List();
        IsTrue(list.Any(_ => _.name == name));
        IsTrue(list.Any(_ => _.id == id));

        await WinGet.Uninstall(name, false);
        list = await WinGet.List();
        IsFalse(list.Any(_ => _.name == name));
        IsFalse(list.Any(_ => _.id == id));
    }

    [Test]
    public async Task ListAndAcceptSourceAgreements()
    {
        await WinGet.ResetSources();

        // This should not throw
        await WinGet.List();
    }

    [Test]
    public async Task GetVersion()
    {
        var version = await WinGet.GetVersion();
        Greater(3, version.Major);
    }
}
#endif