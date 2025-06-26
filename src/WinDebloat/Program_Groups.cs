﻿public static partial class Program
{
    public static List<Group> Groups =
    [
        new(
            "3D Viewer",
            true,
            new UninstallJob(
                "3D Viewer",
                Notes: " * [AppStore: 3D Viewer](https://apps.microsoft.com/store/detail/3d-viewer/9NBLGGH42THS)")),
        new(
            "Advertiser Id",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                "Enabled",
                0,
                1,
                Notes: " * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)")),
        new(
            "Camera",
            true,
            new UninstallJob(
                "Windows Camera",
                Notes: " * [AppStore: Windows Camera](https://apps.microsoft.com/store/detail/windows-camera/9WZDNCRFJBBG)")),
        new(
            "Chat",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0,
                1,
                Notes: " * [Managing the Teams Chat icon on Windows 11](https://learn.microsoft.com/en-us/troubleshoot/windows-client/application-management/managing-teams-chat-icon-windows-11)")),
        new(
            "Clock",
            false,
            [
                new UninstallJob(
                    "Windows Clock",
                    Notes: " * [AppStore: Windows Clock](https://apps.microsoft.com/store/detail/windows-clock/9WZDNCRFJ3PR)"),
                new UninstallJob("Windows Alarms & Clock"),
            ]),
        new(
            "Clipchamp",
            true,
            new UninstallJob(
                "Clipchamp",
                Notes: " * [AppStore: Clipchamp](https://apps.microsoft.com/store/detail/microsoft-clipchamp/9P1J8S7CCWWT)")),
        new("Cortana", true, new UninstallJob("Cortana")),
        new(
            "Copilot",
            false,
            [
                new UninstallJob("Microsoft Copilot"),
                new UninstallJob("Microsoft 365 Copilot")
            ]),
        new(
            "Customize This Folder",
            false,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer",
                "NoCustomizeThisFolder",
                1,
                0,
                Notes:
                """
                * Removes Explorer "Customize this folder" functionality. Both from the context menu and from the properties tab.
                """)),
        new(
            "Default Browser Prompt",
            false,
            [
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Policies\Google\Chrome",
                    "DefaultBrowserSettingEnabled",
                    0,
                    1,
                    Notes:
                    """
                    * Disables the prompt to set chrome as the default browser
                    * Use [Change Default Apps in Windows](https://support.microsoft.com/en-au/windows/change-default-apps-in-windows-e5d82cad-17d1-c53b-3505-f10a32e1894d) to manually control the default browser
                    """),
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Policies\Microsoft\Edge",
                    "DefaultBrowserSettingEnabled",
                    0,
                    1,
                    Notes:
                    """
                    * Disables the prompt to set edge as the default browser
                    * Use [Change Default Apps in Windows](https://support.microsoft.com/en-au/windows/change-default-apps-in-windows-e5d82cad-17d1-c53b-3505-f10a32e1894d) to manually control the default browser
                    """),
            ]),
        new(
            "DevHome",
            false,
            new UninstallJob(
                "DevHome",
                Notes: " * [Dev Home](https://learn.microsoft.com/en-us/windows/dev-home/)",
                PartialMatch: true)),
        new(
            "dotnet",
            false,
            new EnvironmentVariableJob(
                "dotnetTelemetry",
                "DOTNET_CLI_TELEMETRY_OPTOUT",
                "true",
                Notes: " * [Opt out of .NET SDK and .NET CLI telemetry](https://learn.microsoft.com/en-us/dotnet/core/tools/telemetry#how-to-opt-out)")),
        new(
            "Developer Mode",
            false,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Windows\Appx",
                "AllowDevelopmentWithoutDevLicense",
                1,
                0,
                Notes: " * [Developer Mode features and debugging](https://learn.microsoft.com/en-us/windows/apps/get-started/developer-mode-features-and-debugging)")),
        new(
            "Edge Bing SideBar",
            false,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Edge",
                "HubsSidebarEnabled",
                0,
                1,
                Notes:
                """
                * [Microsoft Edge now has a Bing AI chatbot sidebar](https://www.theverge.com/2023/3/14/23639375/microsoft-edge-bing-ai-sidebar-chatbot-feature)
                * Disables the Edge Bing Sidebar <br><img src="/src/edgeBingIcon.png" height="200px">
                """)),
        new(
            "Edge Desktop Search Bar",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Edge",
                "WebWidgetAllowed",
                0,
                1,
                Notes: " * [Enable the Search bar ](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#webwidgetallowed)")),
        new(
            "Edge Default Location To Blank",
            false,
            [
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"SOFTWARE\Policies\Microsoft\Edge",
                    "HomepageLocation",
                    "about:blank",
                    null,
                    RegistryValueKind.String,
                    Notes: " * [Set home page to blank](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#homepagelocation)"),
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"SOFTWARE\Policies\Microsoft\Edge",
                    "NewTabPageLocation",
                    "about:blank",
                    null,
                    RegistryValueKind.String,
                    Notes: " * [Set new tab to blank](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#newtabpagelocation)")
            ]),
        new(
            "EdgeRecommendations",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Edge",
                "ShowRecommendationsEnabled",
                0,
                1,
                Notes:
                """
                * [Allow feature recommendations and browser assistance notifications from Microsoft Edge](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#showrecommendationsenabled)
                * Disables "Switch default search engine Microsoft Bing in Chrome" <br><img src="/src/SwitchToBingInChrome.png" height="200px">
                """)),
        new(
            "Explorer 3D Objects",
            true,
            new RegistryKeyJob(
                RegistryHive.LocalMachine,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}",
                Invert: true)
        ),
        new(
            "Explorer Classic Menu",
            false,
            new RegistryKeyJob(
                RegistryHive.CurrentUser,
                @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32")),
        new(
            "Feedback Hub",
            true,
            new UninstallJob("Feedback Hub")),
        new(
            "FileExtensions",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0,
                1)),
        new(
            "FilmsAndTV",
            true,
            new UninstallJob("Films & TV")),
        new(
            "Games",
            true,
            [
                new UninstallJob("Solitaire & Casual Games"),
                new UninstallJob("Microsoft Solitaire Collection")
            ]),
        new("Get Help", true, new UninstallJob("Get Help")),
        new(
            "Give Access To",
            false,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked",
                "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}",
                "",
                null,
                RegistryValueKind.String,
                Notes:
                """
                * Removes Explorer "Give access to" functionality. Both from the context menu and from the properties tab.
                """)),
        new(
            "Health Check", false,
            new UninstallJob(
                "Windows PC Health Check",
                Notes: " * [How to use the PC Health Check app](https://support.microsoft.com/en-us/windows/how-to-use-the-pc-health-check-app-9c8abd9b-03ba-4e67-81ef-36f37caa7844)")),
        new(
            "HP Vendorware",
            "HP",
            false,
            [
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
            ]),
        new("Internet Connection Sharing", true, new UninstallJob("SharedAccess")),
        new(
            "Lock Screen Ads",
            true,
            [
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "RotatingLockScreenOverlayEnabled",
                    0,
                    1,
                    Notes: " * [Configure Windows Spotlight on the lock screen](https://learn.microsoft.com/en-us/windows/configuration/windows-spotlight)"),
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "SubscribedContent-338387Enabled",
                    0,
                    1),
            ]),
        new(
            "Learn about this image",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel",
                "{2cc5ca98-6485-489a-920e-b3e88a6ccce3}",
                1,
                null,
                Notes:
                """
                * Removes "Learn about this image" from the desktop <br><img src="/src/LearnAboutThisImage.png" height="200px">
                * [How to Remove the ‘Learn More About this Picture’ Icon in Windows 11](https://www.digitbin.com/remove-learn-about-this-picture-icon-windows-11/).
                """)),
        new("Mail and Calendar", true, new UninstallJob("Mail and Calendar")),
        new(
            "Maps",
            true,
            [
                new UninstallJob("Windows Maps"),
                new DisableServiceJob("MapsBroker")
            ]),
        new("Media Player", true, new UninstallJob("Windows Media Player")),
        new("Mixed Reality Portal", true, new UninstallJob("Mixed Reality Portal")),
        new("Movies and TV", true, new UninstallJob("Movies & TV")),
        new(
            "News",
            true,
            [
                new UninstallJob("Microsoft News"),
                new UninstallJob("News")
            ]),
        new("OneNote", true, new UninstallJob("OneNote for Windows 10")),
        new("Office 365", false, new UninstallJob("Microsoft 365 (Office)")),
        new(
            "Office Cloud Files",
            false,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer",
                "ShowCloudFilesInQuickAccess",
                0,
                1,
                Notes:
                """
                * Disables Office cloud files in explorer<br>
                  <img src="/src/OfficeExplorer.png" height="200px"><br>
                  <img src="/src/OfficeExplorerDialog.png" height="150px"><br>
                  <img src="/src/OfficeExplorerOptions.png" height="300px">
                """)),
        new(
            "OneDrive",
            false,
            [
                new UninstallJob(
                    "Microsoft OneDrive",
                    Notes: " * [OneDrive Personal Cloud Storage](https://www.microsoft.com/en-au/microsoft-365/onedrive/online-cloud-storage)",
                    true),
                new UninstallJob(
                    "OneDrive",
                    Notes: null,
                    true),
            ]
        ),
        new("Paint 3D", true, new UninstallJob("Paint 3D")),
        new(
            "Paint",
            false,
            [
                new UninstallJob("Paint"),
                new InstallJob("paint.net"),
            ]),
        new("Pay", true, new UninstallJob("Microsoft Pay")),
        new("People", true, new UninstallJob("Microsoft People")),
        new(
            "Phone Link",
            false,
            new UninstallJob(
                "Phone Link",
                Notes: " * [AppStore: Phone Link](https://apps.microsoft.com/store/detail/phone-link/9NMPJ99VJBWV)")),
        new("Photos", true, new UninstallJob("Microsoft Photos")),
        new("Power Automate", true, new UninstallJob("Power Automate")),
        new(
            "PowerShell Unrestricted",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
                "ExecutionPolicy",
                "Unrestricted",
                "Restricted",
                RegistryValueKind.String)),
        new("Printer", false, new DisableServiceJob("Spooler")),
        new("Print 3D", true, new UninstallJob("Print 3D")),
        new(
            "Program Compatibility Assistant",
            false,
            new DisableServiceJob("PcaSvc")),
        new(
            "Quick Assist",
            false,
            new UninstallJob(
                "Quick Assist",
                Notes: " * [Solve PC problems over a remote connection](https://support.microsoft.com/en-us/windows/solve-pc-problems-over-a-remote-connection-b077e31a-16f4-2529-1a47-21f6a9040bf3)")),
        new(
            "Skype",
            true,
            new UninstallJob(
                "Skype",
                Notes: " * [AppStore: Skype](https://apps.microsoft.com/store/detail/skype/9WZDNCRFJ364)")),
        new(
            "Spotify",
            true,
            new UninstallJob("Spotify Music")),
        new(
            "Startup boost",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0,
                1,
                Notes: " * [Microsoft Edge Startup boost](https://www.microsoft.com/en-us/edge/features/startup-boost)")
        ),
        new(
            "Start Menu Recommendations",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "HideRecommendedSection",
                1,
                0,
                Notes:
                """
                 * The parent path `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer` may need to be created if it doesn;t exist
                 * [Policy CSP - Start / hiderecommendedsection](https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-start#hiderecommendedsection)
                """)),
        new(
            "Sticky Notes",
            true,
            new UninstallJob(
                "Microsoft Sticky Notes",
                Notes: " * [AppStore: Sticky Notes](https://apps.microsoft.com/store/detail/microsoft-sticky-notes/9NBLGGH4QGHW)")),
        new(
            "TaskBar Search",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Search",
                "SearchboxTaskbarMode",
                0,
                1)),
        new(
            "Task View",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0,
                1)),
        new(
            "Teams",
            false,
            [
                new UninstallJob(
                    "Microsoft.Teams.Classic",
                    Notes: " * [Microsoft Teams](https://www.microsoft.com/en-au/microsoft-teams/group-chat-software)"),
                new UninstallJob("Microsoft Teams (personal)"),
                new UninstallJob("Microsoft Teams Meeting Add-in for Microsoft Office"),
                new UninstallJob("Microsoft Teams"),
            ]),
        new(
            "Teams Installer",
            true,
            new UninstallJob(
                "Teams Machine-Wide Installer",
                Notes: " * [Bulk install Teams using Windows Installer](https://learn.microsoft.com/en-us/microsoftteams/msi-deployment)")),
        new(
            "Telemetry",
            true,
            [
                new RegistryValueJob(
                    RegistryHive.LocalMachine,
                    @"SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    "Allow Telemetry",
                    0,
                    1),
                new DisableServiceJob("DiagTrack")
            ]),
        new(
            "Tips",
            true,
            new UninstallJob("Microsoft Tips")),
        new("To Do",
            true,
            new UninstallJob(
                "Microsoft To Do",
                Notes: " * [AppStore: To Do](https://apps.microsoft.com/store/detail/microsoft-to-do-lists-tasks-reminders/9NBLGGH5R558)")),
        new("Voice Recorder", false, new UninstallJob("Windows Voice Recorder")),
        new("Weather", true, new UninstallJob("MSN Weather")),
        new("Web Experience Pack", true, new UninstallJob("Windows Web Experience Pack")),
        new(
            "Start Menu Web Search",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "DisableSearchBoxSuggestions",
                1,
                0)),
        new("Whiteboard", true, new UninstallJob("Microsoft Whiteboard")),
        new(
            "Widgets",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0,
                1)),
        new(
            "Xbox",
            true,
            [
                new UninstallJob("Xbox TCUI"),
                new UninstallJob("Xbox Console Companion"),
                new UninstallJob("Xbox Game Bar Plugin"),
                new UninstallJob("Xbox Identity Provider"),
                new UninstallJob("Xbox Game Speech Window"),
                new UninstallJob("Xbox Game Bar"),
                new UninstallJob("Xbox Accessories"),
                new UninstallJob("Xbox"),
            ]),
    ];
}