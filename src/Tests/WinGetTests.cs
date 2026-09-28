#if DEBUG
[Explicit]
public class WinGetTests
{
    string name = "GitHub CLI";
    string id = "GitHub.cli";

    [Test]
    public async Task AlreadyInstalledName()
    {
        await WinGet.InstallByName(name);
        await WinGet.InstallByName(name);
    }

    [Test]
    public async Task AlreadyInstalledId()
    {
        await WinGet.InstallById(id);
        await WinGet.InstallById(id);
    }

    [Test]
    public async Task AlreadyUninstalledName()
    {
        await WinGet.UninstallByName(name);
        await WinGet.UninstallByName(name);
    }

    [Test]
    public async Task AlreadyUninstalledId()
    {
        await WinGet.UninstallById(id);
        await WinGet.UninstallById(id);
    }

    [Test]
    public async Task InstallName()
    {
        await WinGet.InstallByName(name);
        var list = await WinGet.List();
        await Assert.That(list.Any(_ => _.name == name)).IsTrue();
        await Assert.That(list.Any(_ => _.id == id)).IsTrue();

        await WinGet.UninstallByName(name);
        list = await WinGet.List();
        await Assert.That(list.Any(_ => _.name == name)).IsFalse();
        await Assert.That(list.Any(_ => _.id == id)).IsFalse();
    }

    [Test]
    public async Task InstallId()
    {
        await WinGet.InstallById(id);
        var list = await WinGet.List();
        await Assert.That(list.Any(_ => _.name == name)).IsTrue();
        await Assert.That(list.Any(_ => _.id == id)).IsTrue();

        await WinGet.UninstallById(id);
        list = await WinGet.List();
        await Assert.That(list.Any(_ => _.name == name)).IsFalse();
        await Assert.That(list.Any(_ => _.id == id)).IsFalse();
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
        await Assert.That(version.Major).IsLessThan(3);
    }
}
#endif