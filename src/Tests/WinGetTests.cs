[TestFixture]
public class WinGetTests
{
    string name = "GitHub CLI";
    string id = "GitHub.cli";

    [Test]
    public async Task AlreadyInstalled()
    {
        await WinGet.InstallById(id);
        await WinGet.InstallById(id);
        await WinGet.InstallByName(name);
    }

    [Test]
    public async Task AlreadyUninstalled()
    {
        await WinGet.UninstallById(id);
        await WinGet.UninstallById(id);
        await WinGet.UninstallByName(name);
    }

    [Test]
    public async Task IdTest()
    {
        await WinGet.InstallById(id);
        var list = await WinGet.List();
        Assert.IsTrue(list.Any(_ => _.Id == id));

        await WinGet.UninstallById(id);
        list = await WinGet.List();
        Assert.IsFalse(list.Any(_ => _.Id == id));
    }

    [Test]
    public async Task NameTest()
    {
        await WinGet.InstallByName(name);
        var list = await WinGet.List();
        Assert.IsTrue(list.Any(_ => _.Name == name));

        await WinGet.UninstallByName(name);
        list = await WinGet.List();
        Assert.IsFalse(list.Any(_ => _.Name == name));
    }

    [Test]
    [NonParallelizable]
    public async Task ListAndAcceptSourceAgreements()
    {
        await WinGet.ResetSources();
        await WinGet.List(); // This should not throw
    }
}