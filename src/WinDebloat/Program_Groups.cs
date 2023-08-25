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
        new(
            "Calculator",
            false,
            new UninstallJob(
                "Windows Calculator",
                Notes: " * [AppStore: Windows Calculator](https://apps.microsoft.com/store/detail/windows-calculator/9WZDNCRFHVN5)")),
        new(
            "Camera",
            true,
            new UninstallJob(
                "Windows Camera",
                Notes: " * [AppStore: Windows Camera](https://apps.microsoft.com/store/detail/windows-camera/9WZDNCRFJBBG)")),
        new(
            "Chat",
            true,
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0,
                1,
                Notes: " * [Managing the Teams Chat icon on Windows 11](https://learn.microsoft.com/en-us/troubleshoot/windows-client/application-management/managing-teams-chat-icon-windows-11)")),
        new(
            "Clock",
            false,
            new UninstallJob(
                "Windows Clock",
                Notes: " * [AppStore: Windows Clock](https://apps.microsoft.com/store/detail/windows-clock/9WZDNCRFJ3PR)")),
        new(
            "Clipchamp",
            true,
            new UninstallJob(
                "Clipchamp",
                Notes: " * [AppStore: Clipchamp](https://apps.microsoft.com/store/detail/microsoft-clipchamp/9P1J8S7CCWWT)")),
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
        new("Internet Connection Sharing", true, new UninstallJob("SharedAccess")),
        new(
            "HP Vendorware",
            "HP",
            false,
            new IJob[]
            {
                new UninstallJob("HP Desktop Support Utilities"),
                new UninstallJob("HP Documentation"),
                new UninstallJob("HP Notifications"),
                new UninstallJob("HPHelp"),
                new DisableServiceJob("HpTouchpointAnalyticsService"),
                new DisableServiceJob("HPAppHelperCap"),
                new DisableServiceJob("HPDiagsCap"),
                new DisableServiceJob("HPSysInfoCap"),
                new DisableServiceJob("hpsvcsscan"),
                new DisableServiceJob("HotKeyServiceDSU")
            }),
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
        new("Maps",
            true,
            new IJob[]
            {
                new UninstallJob("Windows Maps"),
                new DisableServiceJob("MapsBroker")
            }),
        new("Media Player", true, new UninstallJob("Windows Media Player")),
        new("Mixed Reality Portal", true, new UninstallJob("Mixed Reality Portal")),
        new("Movies and TV", true, new UninstallJob("Movies & TV")),
        new("News", true, new UninstallJob("News")),
        new("OneNote", true, new UninstallJob("OneNote for Windows 10")),
        new("Paint 3D", true, new UninstallJob("Paint 3D")),
        new(
            "Paint",
            false,
            new IJob[]
            {
                new UninstallJob("Paint"),
                new InstallJob("paint.net"),
            }),
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
                "Restricted",
                RegistryValueKind.String)),
        new("Printer", false, new DisableServiceJob("Spooler")),
        new("Print 3D", true, new UninstallJob("Print 3D")),
        new(
            "Skype",
            true,
            new UninstallJob(
                "Skype",
                Notes: " * [AppStore: Skype](https://apps.microsoft.com/store/detail/skype/9WZDNCRFJ364)")),
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
                0,
                Notes: @" * The parent path `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer` may need to be created if it doesn;t exist")),
        new(
            "Sticky Notes",
            true,
            new UninstallJob(
                "Microsoft Sticky Notes",
                Notes: " * [AppStore: Sticky Notes](https://apps.microsoft.com/store/detail/microsoft-sticky-notes/9NBLGGH4QGHW)")),
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
        new("Teams Installer", true, new UninstallJob("Teams Machine-Wide Installer")),
        new(
            "Telemetry",
            true,
            new IJob[]
            {
                new RegistryJob(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    "Allow Telemetry",
                    0,
                    1),
                new DisableServiceJob("DiagTrack")
            }),
        new(
            "Tips",
            true,
            new UninstallJob("Microsoft Tips")),
        new("To Do",
            true,
            new UninstallJob(
                "Microsoft To Do",
                Notes: " * [AppStore: To Do](https://apps.microsoft.com/store/detail/microsoft-to-do-lists-tasks-reminders/9NBLGGH5R558")),
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