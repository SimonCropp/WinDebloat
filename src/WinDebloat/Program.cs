public static class Program
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

    public static async Task Inner()
    {
        installed = await WinGet.List();
        foreach (var group in Groups)
        {
            Log.Information($"Group: {group.Name}");
            foreach (var job in group.Jobs)
            {
                Log.Information($"  Job: {job.Name}");
                switch (job)
                {
                    case RegistryJob registry:
                        HandleRegistry(registry);
                        continue;
                    case InstallJob installJob:
                        await HandleInstall(installJob);
                        continue;
                    case UninstallJob uninstallJob:
                        await HandleUninstall(uninstallJob);
                        continue;
                }
            }
        }

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

        foreach (var package in toUninstall)
        {
            if (!IsInstalled(package))
            {
                Log.Information($"Skipping uninstall of {package} since not installed");
                continue;
            }

            await WinGet.Uninstall(package);
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

            await WinGet.Install(package);
        }
    }

    static async Task HandleUninstall(UninstallJob uninstall)
    {
        if (IsInstalled(uninstall.Name))
        {
            await WinGet.Install(uninstall.Name);
            return;
        }

        Log.Information($"    Skipping uninstall of '{uninstall.Name}' since already uninstalled");
    }

    static async Task HandleInstall(InstallJob install)
    {
        if (IsInstalled(install.Name))
        {
            Log.Information($"    Skipping install of '{install.Name}' since already installed");
            return;
        }

        await WinGet.Install(install.Name);
    }

    static bool IsInstalled(string package) =>
        installed.Any(_ => string.Equals(_, package, StringComparison.OrdinalIgnoreCase));

    static void HandleRegistry(RegistryJob registry)
    {
        var (key, name, value, kind, _) = registry;
        Log.Information(@$"    Registry target {key}\{name} to {value} ({kind})");
        var currentValue = Registry.GetValue(key, name, null);
        if (value.Equals(currentValue))
        {
            Log.Information($"      Value is already {value}");
            return;
        }

        Registry.SetValue(key, name, value, kind);
    }

    public static List<Group> Groups = new()
    {
        new(
            "DisableLockScreenAds",
            new[]
            {
                new RegistryJob(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "RotatingLockScreenOverlayEnabled",
                    0),
                new RegistryJob(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "SubscribedContent-338387Enabled",
                    0),
            }),
        new(
            "RemoveChat",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0)),
        new(
            "DisableTelemetry",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                "Allow Telemetry",
                0)),
        new(
            "DisableAdvertiserId",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                "Enabled",
                0)),
        new(
            "RemoveWidgets",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0)),
        new(
            "HideStartMenuRecommendedSection",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "HideRecommendedSection",
                1)),
        new(
            "DisableStartupBoost",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0)),
        new(
            "RemoveTaskView",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0)),
        new(
            "RemoveTaskBarSearch",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                "SearchboxTaskbarMode",
                0)),
        new(
            "EnableFileExtensions",
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0)),
        new(
            "EnableDeveloperMode",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
                "AllowDevelopmentWithoutDevLicense",
                1,
                Notes: " * https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development")),
        new(
            "MakePowerShelUnrestricted",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
                "ExecutionPolicy",
                "Unrestricted",
                RegistryValueKind.String)),
        new(
            "DisableWebSearch",
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "DisableSearchBoxSuggestions",
                1)),
        new(
            "DisableEdgeDesktopSearchBar",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "WebWidgetAllowed",
                0)),
    };

    static List<string> installed = null!;
}