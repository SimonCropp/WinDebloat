[TestFixture]
public class WinGetTests
{
    [Test]
    public async Task Test()
    {
        await WinGet.Install("Windows Calculator");
        var list = await WinGet.List();
        Assert.IsTrue(list.Any(_ => _ == "Windows Calculator"));

        await WinGet.Uninstall("Windows Calculator");
        list = await WinGet.List();
        Assert.IsFalse(list.Any(_ => _ == "Windows Calculator"));
    }
}