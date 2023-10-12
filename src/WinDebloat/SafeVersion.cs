public static class SafeVersion
{
    public static Version Parse(string version)
    {
        var hasPrereleaseTag = version.IndexOf('-');

        return Version.Parse(hasPrereleaseTag != -1
            ? version[1..hasPrereleaseTag]
            : version[1..]);
    }
}