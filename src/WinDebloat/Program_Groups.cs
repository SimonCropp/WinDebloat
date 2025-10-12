public static partial class Program
{
    public static List<Group> Groups =
    [
        new(
            "3D Viewer",
            true,
            new UninstallByNameJob(
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
                "AdvertisingInfo",
                Notes: " * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)")),
        new(
            "Bing Desktop Visual Search",
            true,
            [
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "ShowVisualSearchDesktopIcon",
                    0,
                    1,
                    "ShowVisualSearchDesktopIcon",
                    Notes:  """
                            * Disables the Bing "Visual search to find similar images" on the desktop <br><img src="/src/VisualSearchToFindSimilarImages.png"/>
                            * Prevents launching a browser with Bing search when the desktop is clicked
                            * [Learn Microsoft - How to turn off or move the new Visual Search desktop icon](https://learn.microsoft.com/en-us/answers/questions/5575751/how-to-turn-off-or-move-the-new-visual-search-desk)
                            """)
            ]),
        new(
            "Camera",
            true,
            new UninstallByNameJob(
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
                "TaskbarMn",
                Notes: " * [Managing the Teams Chat icon on Windows 11](https://learn.microsoft.com/en-us/troubleshoot/windows-client/application-management/managing-teams-chat-icon-windows-11)")),
        new(
            "Clock",
            false,
            [
                new UninstallByNameJob(
                    "Windows Clock",
                    Notes: " * [AppStore: Windows Clock](https://apps.microsoft.com/store/detail/windows-clock/9WZDNCRFJ3PR)"),
                new UninstallByNameJob("Windows Alarms & Clock"),
            ]),
        new(
            "Clipchamp",
            true,
            new UninstallByNameJob(
                "Clipchamp",
                Notes: " * [AppStore: Clipchamp](https://apps.microsoft.com/store/detail/microsoft-clipchamp/9P1J8S7CCWWT)")),
        new("Cortana", true, new UninstallByNameJob("Cortana")),
        new(
            "Copilot",
            false,
            [
                new UninstallByNameJob("Microsoft Copilot"),
                new UninstallByNameJob("Microsoft 365 Copilot"),
                new UninstallByNameJob("Copilot"),
                new RegistryValueJob(
                    RegistryHive.LocalMachine,
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked",
                    "{CB3B0003-8088-4EDE-8769-8B354AB2FF8C}",
                    "",
                    null,
                    "Explorer: Ask Copilot",
                    RegistryValueKind.String,
                    Notes: " * Remove 'Ask Copilot' from Right-Click Menu in File Explorer."),
                new RegistryValueJob(
                    RegistryHive.LocalMachine,
                    @"SOFTWARE\Policies\WindowsNotepad",
                    "DisableAIFeatures",
                    1,
                    0,
                    "Copilot Notepad"),
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
                "NoCustomizeThisFolder",
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
                    "Chrome DefaultBrowserSettingEnabled",
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
                    "Edge DefaultBrowserSettingEnabled",
                    Notes:
                    """
                    * Disables the prompt to set edge as the default browser
                    * Use [Change Default Apps in Windows](https://support.microsoft.com/en-au/windows/change-default-apps-in-windows-e5d82cad-17d1-c53b-3505-f10a32e1894d) to manually control the default browser
                    """),
            ]),
        new(
            "DevHome",
            false,
            new UninstallByIdJob(
                "Microsoft.DevHome",
                Notes: " * [Dev Home](https://learn.microsoft.com/en-us/windows/dev-home/)")),
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
                "AllowDevelopmentWithoutDevLicense",
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
                "HubsSidebarEnabled",
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
                "WebWidgetAllowed",
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
                    "HomepageLocation",
                    RegistryValueKind.String,
                    Notes: " * [Set home page to blank](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#homepagelocation)"),
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"SOFTWARE\Policies\Microsoft\Edge",
                    "NewTabPageLocation",
                    "about:blank",
                    null,
                    "NewTabPageLocation",
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
                "ShowRecommendationsEnabled",
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
            new UninstallByNameJob("Feedback Hub")),
        new(
            "FileExtensions",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0,
                1,
                "HideFileExt")),
        new(
            "FilmsAndTV",
            true,
            new UninstallByNameJob("Films & TV")),
        new(
            "Games",
            true,
            [
                new UninstallByNameJob("Solitaire & Casual Games"),
                new UninstallByNameJob("Microsoft Solitaire Collection")
            ]),
        new("Game Assist", false, new UninstallByNameJob("Microsoft Edge Game Assist")),
        new("Get Help", true, new UninstallByNameJob("Get Help")),
        new(
            "Give Access To",
            false,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked",
                "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}",
                "",
                null,
                "Block `Give Access To`",
                RegistryValueKind.String,
                Notes:
                """
                * Removes Explorer "Give access to" functionality. Both from the context menu and from the properties tab.
                """)),
        new(
            "Health Check", false,
            new UninstallByNameJob(
                "Windows PC Health Check",
                Notes: " * [How to use the PC Health Check app](https://support.microsoft.com/en-us/windows/how-to-use-the-pc-health-check-app-9c8abd9b-03ba-4e67-81ef-36f37caa7844)")),
        new(
            "HP Vendorware",
            "HP",
            false,
            [
                new UninstallByNameJob("HP Desktop Support Utilities"),
                new UninstallByNameJob("HP Documentation"),
                new UninstallByNameJob("HP Notifications"),
                new UninstallByNameJob("HPHelp"),
                new DisableServiceJob("HpTouchpointAnalyticsService"),
                new DisableServiceJob("HPAppHelperCap"),
                new DisableServiceJob("HPDiagsCap"),
                new DisableServiceJob("HPSysInfoCap"),
                new DisableServiceJob("hpsvcsscan"),
                new DisableServiceJob("HotKeyServiceDSU")
            ]),
        new("Internet Connection Sharing", true, new UninstallByNameJob("SharedAccess")),
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
                    "RotatingLockScreenOverlayEnabled",
                    Notes: " * [Configure Windows Spotlight on the lock screen](https://learn.microsoft.com/en-us/windows/configuration/windows-spotlight)"),
                new RegistryValueJob(
                    RegistryHive.CurrentUser,
                    @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "SubscribedContent-338387Enabled",
                    0,
                    1,
                    "SubscribedContent"),
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
                "NewStartPanel",
                Notes:
                """
                * Removes "Learn about this image" from the desktop <br><img src="/src/LearnAboutThisImage.png" height="200px">
                * [How to Remove the ‘Learn More About this Picture’ Icon in Windows 11](https://www.digitbin.com/remove-learn-about-this-picture-icon-windows-11/).
                """)),
        new("Mail and Calendar", true, new UninstallByNameJob("Mail and Calendar")),
        new(
            "Maps",
            true,
            [
                new UninstallByNameJob("Windows Maps"),
                new DisableServiceJob("MapsBroker")
            ]),
        new("Media Player", true, new UninstallByNameJob("Windows Media Player")),
        new("Mixed Reality Portal", true, new UninstallByNameJob("Mixed Reality Portal")),
        new("Movies and TV", true, new UninstallByNameJob("Movies & TV")),
        new(
            "News",
            true,
            [
                new UninstallByNameJob("Microsoft News"),
                new UninstallByNameJob("News")
            ]),
        new("OneNote", true, new UninstallByNameJob("OneNote for Windows 10")),
        new("Office 365", false, new UninstallByNameJob("Microsoft 365 (Office)")),
        new(
            "Office Cloud Files",
            false,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer",
                "ShowCloudFilesInQuickAccess",
                0,
                1,
                "ShowCloudFilesInQuickAccess",
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
            new UninstallByIdJob(
                "Microsoft.OneDrive",
                Notes: " * [OneDrive Personal Cloud Storage](https://www.microsoft.com/en-au/microsoft-365/onedrive/online-cloud-storage)")
        ),
        new("Paint 3D", true, new UninstallByNameJob("Paint 3D")),
        new(
            "Paint",
            false,
            [
                new UninstallByNameJob("Paint"),
                new InstallByNameJob("paint.net"),
            ]),
        new("Pay", true, new UninstallByNameJob("Microsoft Pay")),
        new("People", true, new UninstallByNameJob("Microsoft People")),
        new(
            "Phone Link",
            false,
            new UninstallByNameJob(
                "Phone Link",
                Notes: " * [AppStore: Phone Link](https://apps.microsoft.com/store/detail/phone-link/9NMPJ99VJBWV)")),
        new("Photos", true, new UninstallByNameJob("Microsoft Photos")),
        new("Power Automate", true, new UninstallByNameJob("Power Automate")),
        new(
            "PowerShell Unrestricted",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
                "ExecutionPolicy",
                "Unrestricted",
                "Restricted",
                "ExecutionPolicy",
                RegistryValueKind.String)),
        new("Printer", false, new DisableServiceJob("Spooler")),
        new("Print 3D", true, new UninstallByNameJob("Print 3D")),
        new(
            "Program Compatibility Assistant",
            false,
            new DisableServiceJob("PcaSvc")),
        new(
            "Quick Assist",
            false,
            new UninstallByNameJob(
                "Quick Assist",
                Notes: " * [Solve PC problems over a remote connection](https://support.microsoft.com/en-us/windows/solve-pc-problems-over-a-remote-connection-b077e31a-16f4-2529-1a47-21f6a9040bf3)")),
        new(
            "Skype",
            true,
            new UninstallByNameJob(
                "Skype",
                Notes: " * [AppStore: Skype](https://apps.microsoft.com/store/detail/skype/9WZDNCRFJ364)")),
        new(
            "Spotify",
            true,
            new UninstallByNameJob("Spotify Music")),
        new(
            "Startup boost",
            true,
            new RegistryValueJob(
                RegistryHive.LocalMachine,
                @"SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0,
                1,
                "StartupBoostEnabled",
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
                "HideRecommendedSection",
                Notes:
                """
                 * The parent path `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer` may need to be created if it doesn;t exist
                 * [Policy CSP - Start / hiderecommendedsection](https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-start#hiderecommendedsection)
                """)),
        new(
            "Sticky Notes",
            true,
            new UninstallByNameJob(
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
                1,
                "SearchboxTaskbarMode")),
        new(
            "Task View",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0,
                1,
                "ShowTaskViewButton")),
        new(
            "Teams",
            false,
            [
                new UninstallByIdJob(
                    "Microsoft.Teams.Classic",
                    Notes: " * [Microsoft Teams](https://www.microsoft.com/en-au/microsoft-teams/group-chat-software)"),
                new UninstallByIdJob("Microsoft.Teams.Free"),
                new UninstallByIdJob("Microsoft.Teams")
            ]),
        new(
            "Teams Installer",
            true,
            new UninstallByNameJob(
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
                    1,
                    "Allow Telemetry"),
                new DisableServiceJob("DiagTrack")
            ]),
        new(
            "Tips",
            true,
            new UninstallByNameJob("Microsoft Tips")),
        new("To Do",
            true,
            new UninstallByNameJob(
                "Microsoft To Do",
                Notes: " * [AppStore: To Do](https://apps.microsoft.com/store/detail/microsoft-to-do-lists-tasks-reminders/9NBLGGH5R558)")),
        new("Voice Recorder", false, new UninstallByNameJob("Windows Voice Recorder")),
        new("Weather", true, new UninstallByNameJob("MSN Weather")),
        new("Web Experience Pack", true, new UninstallByNameJob("Windows Web Experience Pack")),
        new(
            "Start Menu Web Search",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "DisableSearchBoxSuggestions",
                1,
                0,
                "DisableSearchBoxSuggestions")),
        new("Whiteboard", true, new UninstallByNameJob("Microsoft Whiteboard")),
        new(
            "Widgets",
            true,
            new RegistryValueJob(
                RegistryHive.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0,
                1,
                "TaskbarDa")),
        new(
            "Xbox",
            true,
            [
                new UninstallByNameJob("Xbox TCUI"),
                new UninstallByNameJob("Xbox Console Companion"),
                new UninstallByNameJob("Xbox Game Bar Plugin"),
                new UninstallByNameJob("Xbox Identity Provider"),
                new UninstallByNameJob("Xbox Game Speech Window"),
                new UninstallByNameJob("Xbox Game Bar"),
                new UninstallByNameJob("Xbox Accessories"),
                new UninstallByNameJob("Xbox"),
            ]),
    ];
}