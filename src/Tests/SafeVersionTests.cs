public class VersionExtensionsTests
{
    public static IEnumerable<(string, Version)> GetVersionTestData()
    {
        yield return ("v1.2.3", new Version(1, 2, 3));
        yield return ("v1.2.3.4", new Version(1, 2, 3, 4));
        yield return ("v1.2.3-prerelease", new Version(1, 2, 3));
        yield return ("v1.2.3.4-prerelease", new Version(1, 2, 3, 4));
    }

    [Test]
    [MethodDataSource(nameof(GetVersionTestData))]
    public async Task VersionParse(string input, Version expected)
    {
        var actual = SafeVersion.Parse(input);
        await Assert.That(actual).IsEqualTo(expected);
    }
}