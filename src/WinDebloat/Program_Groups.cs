public static partial class Program
{
    public static List<Group> Groups = new()
    {
        new(
            "Advertiser Id",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                "Enabled",
                0,
                1,
                Notes: " * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)")),
        new("Camera", true, new UninstallJob("Windows Camera")),
        new(
            "Chat",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0,
                1)),
        new("Clipchamp", true, new UninstallJob("Clipchamp")),
        new("Cortana", true, new UninstallJob("Cortana")),
        new(
            "Developer Mode",
            false,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
                "AllowDevelopmentWithoutDevLicense",
                1,
                0,
                Notes: " * [Developer Mode features and debugging](https://learn.microsoft.com/en-us/windows/apps/get-started/developer-mode-features-and-debugging)")),
        new(
            "Edge Desktop Search Bar",
            true,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "WebWidgetAllowed",
                0,
                1)),
        new("Feedback Hub",
            true,
            new UninstallJob("Feedback Hub")),
        new(
            "FileExtensions",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0,
                1)),
        new("Games", true, new UninstallJob("Solitaire & Casual Games")),
        new("Get Help", true, new UninstallJob("Get Help")),
        new(
            "Lock Screen Ads",
            true,
            new[]
            {
                new RegistryJob(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "RotatingLockScreenOverlayEnabled",
                    0,
                    1),
                new RegistryJob(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "SubscribedContent-338387Enabled",
                    0,
                    1),
            }),
        new("Mail and Calendar", true, new UninstallJob("Mail and Calendar")),
        new("Maps", true, new UninstallJob("Windows Maps")),
        new("Media Player", true, new UninstallJob("Windows Media Player")),
        new("Mixed Reality Portal", true, new UninstallJob("Mixed Reality Portal")),
        new("Movies and TV", true, new UninstallJob("Movies & TV")),
        new("News", true, new UninstallJob("News")),
        new("OneNote", true, new UninstallJob("OneNote for Windows 10")),
        new(
            "Paint",
            false,
            new IJob[]
            {
                new UninstallJob("Paint"),
                new InstallJob("paint.net"),
            }),
        new("Paint 3D", true, new UninstallJob("Paint 3D")),
        new("Pay", true, new UninstallJob("Microsoft Pay")),
        new("People", true, new UninstallJob("Microsoft People")),
        new("Photos", true, new UninstallJob("Microsoft Photos")),
        new("Power Automate", true, new UninstallJob("Power Automate")),
        new(
            "PowerShell Unrestricted",
            true,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
                "ExecutionPolicy",
                "Unrestricted",
                RegistryValueKind.String)),
        new("Printer Spooler", false, new DisableServiceJob("Printer Spooler")),
        new("Skype", true, new UninstallJob("Skype")),
        new(
            "Startup boost",
            true,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0,
                1,
                Notes: " * [Microsoft Edge Startup boost](https://www.microsoft.com/en-us/edge/features/startup-boost)")
        ),
        new(
            "Start Menu Recommendations",
            true,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "HideRecommendedSection",
                1,
                0)),
        new("Sticky Notes", true, new UninstallJob("Microsoft Sticky Notes")),
        new(
            "TaskBar Search",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                "SearchboxTaskbarMode",
                0,
                1)),
        new(
            "Task View",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0,
                1)),
        new("Teams", true, new UninstallJob("Teams Machine-Wide Installer")),
        new(
            "Telemetry",
            true,
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                "Allow Telemetry",
                0,
                1)),
        new("Tips", true, new UninstallJob("Microsoft Tips")),
        new("To Do", true, new UninstallJob("Microsoft To Do")),
        new("Weather", true, new UninstallJob("MSN Weather")),
        new("Web Experience Pack", true, new UninstallJob("Windows Web Experience Pack")),
        new(
            "Start Menu Web Search",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "DisableSearchBoxSuggestions",
                1,
                0)),
        new("Whiteboard", true, new UninstallJob("Microsoft Whiteboard")),
        new(
            "Widgets",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0,
                1)),
        new(
            "Xbox",
            true,
            new[]
            {
                new UninstallJob("Xbox TCUI"),
                new UninstallJob("Xbox Console Companion"),
                new UninstallJob("Xbox Game Bar Plugin"),
                new UninstallJob("Xbox Identity Provider"),
                new UninstallJob("Xbox Game Speech Window"),
                new UninstallJob("Xbox Game Bar"),
                new UninstallJob("Xbox Accessories"),
                new UninstallJob("Xbox"),
            }),
    };
}