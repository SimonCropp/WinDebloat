public class WinGetVersionNotMetException(Version installedVersion) :
    Exception
{
    public Version InstalledVersion { get; } = installedVersion;
}