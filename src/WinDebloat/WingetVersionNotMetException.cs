public class WinGetVersionNotMetException :
    Exception
{
    public Version InstalledVersion { get; }

    public WinGetVersionNotMetException(Version installedVersion) =>
        InstalledVersion = installedVersion;
}