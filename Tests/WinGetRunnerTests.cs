[TestFixture]
public class WinGetRunnerTests
{
    [Test]
    public Task Install() =>
        Verify(WinGetRunner.Install("KirillOsenkov.MSBuildStructuredLogViewer"));
}