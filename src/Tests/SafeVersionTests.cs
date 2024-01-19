public class VersionExtensionsTests
{
    static IEnumerable<TestCaseData> GetVersionTestData()
    {
        yield return new("v1.2.3", new Version(1, 2, 3));
        yield return new("v1.2.3.4", new Version(1, 2, 3, 4));
        yield return new("v1.2.3-prerelease", new Version(1, 2, 3));
        yield return new("v1.2.3.4-prerelease", new Version(1, 2, 3, 4));
    }

    [TestCaseSource(nameof(GetVersionTestData))]
    public void VersionParse(string input, Version expected)
    {
        var actual = SafeVersion.Parse(input);
        AreEqual(expected, actual);
    }
}