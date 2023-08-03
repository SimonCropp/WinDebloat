static class Program
{
    static async Task Main()
    {
        Logging.Init();

        var stopwatch = Stopwatch.StartNew();
        try
        {
            await Inner();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Failed at startup");
            throw;
        }
        finally
        {
            Log.Information($"Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    static async Task Inner()
    {
        var installedTask = WinGet.List();
        //https://winget.run
        //https://github.com/valinet/ExplorerPatcher
        RemoveChat();
        DisableTelemetry();
        DisableAdvertiserId();
        DisableLockScreenAds();
        DisableSuggestedApps();
        DisableStartupBoost();
        RemoveTaskBarSearch();
        EnableFileExtensions();
        RemoveWidgets();
        HideStartMenuRecommendedSection();
        RemoveTaskView();
        EnableDeveloperMode();
        DisableWebSearch();
        MakePowerShelUnrestricted();

        var toUninstall = new List<string>
        {
            "Teams Machine-Wide Installer",
            "Movies & TV",
            "Xbox TCUI",
            "Xbox Console Companion",
            "Xbox Game Bar Plugin",
            "Xbox Identity Provider",
            "Xbox Game Speech Window",
            "Xbox Game Bar",
            "Xbox Accessories",
            "Xbox",
            "Microsoft Tips",
            "MSN Weather",
            "Windows Media Player",
            "Mail and Calendar",
            "Microsoft Whiteboard",
            "Microsoft Pay",
            "Skype",
            "Windows Maps",
            "Feedback Hub",
            "Microsoft Photos",
            "Windows Camera",
            "Microsoft To Do",
            "Microsoft People",
            "Solitaire & Casual Games",
            "Mixed Reality Portal",
            "Microsoft Sticky Notes",
            "News",
            "Get Help",
            "Paint 3D",
            "Paint",
            "Cortana",
            "Clipchamp",
            "Power Automate",
            "OneNote for Windows 10",
            "Windows Web Experience Pack"
        };

        var installed = await installedTask;

        foreach (var package in toUninstall)
        {
            if (!IsInstalled(package))
            {
                Log.Information($"Skipping uninstall of {package} since not installed");
                continue;
            }

            await WinGet.UninstallByName(package);
        }

        var toInstall = new List<string>
        {
            "paint.net"
        };

        foreach (var package in toInstall)
        {
            if (IsInstalled(package))
            {
                Log.Information($"Skipping install of {package} since already installed");
                continue;
            }

            await WinGet.InstallById(package);
        }

        bool IsInstalled(string package) =>
            installed.Any(_ => string.Equals(_.Name, package, StringComparison.OrdinalIgnoreCase));
    }

    static void RemoveChat() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "TaskbarMn",
            0);

    static void DisableTelemetry() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
            "Allow Telemetry",
            0);

    static void DisableAdvertiserId() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
            "Enabled",
            0);

    //https://superuser.com/questions/1327459/remove-fun-facts-from-spotlight-lock-screen-in-windows-10-home-1803
    static void DisableLockScreenAds()
    {
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "RotatingLockScreenOverlayEnabled",
            0);
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-338387Enabled",
            0);
    }

    static void DisableSuggestedApps()
    {
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SystemPaneSuggestionsEnabled",
            0);
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SilentInstalledAppsEnabled",
            0);
    }

    static void RemoveWidgets() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "TaskbarDa",
            0);

    static void HideStartMenuRecommendedSection() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer",
            "HideRecommendedSection",
            1);

    static void DisableStartupBoost() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
            "StartupBoostEnabled",
            0);

    static void RemoveTaskView() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "ShowTaskViewButton",
            0);

    static void RemoveTaskBarSearch() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
            "SearchboxTaskbarMode",
            0);

    static void EnableFileExtensions() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "HideFileExt",
            0);

    //https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development
    static void EnableDeveloperMode() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
            "AllowDevelopmentWithoutDevLicense",
            1);

    static void MakePowerShelUnrestricted() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
            "ExecutionPolicy",
            "Unrestricted",
            RegistryValueKind.String);

    static void DisableWebSearch() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer",
            "DisableSearchBoxSuggestions",
            1);
}