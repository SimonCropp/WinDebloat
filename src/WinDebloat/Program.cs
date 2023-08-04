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
        new("Teams Machine-Wide Installer", new[] {new UninstallJob("Teams Machine-Wide Installer")}),
        new("Movies & TV", new[] {new UninstallJob("Movies & TV")}),
        new("Microsoft Tips", new[] {new UninstallJob("Microsoft Tips")}),
        new("MSN Weather", new[] {new UninstallJob("MSN Weather")}),
        new("Windows Media Player", new[] {new UninstallJob("Windows Media Player")}),
        new("Mail and Calendar", new[] {new UninstallJob("Mail and Calendar")}),
        new("Microsoft Whiteboard", new[] {new UninstallJob("Microsoft Whiteboard")}),
        new("Microsoft Pay", new[] {new UninstallJob("Microsoft Pay")}),
        new("Skype", new[] {new UninstallJob("Skype")}),
        new("Windows Maps", new[] {new UninstallJob("Windows Maps")}),
        new("Feedback Hub", new[] {new UninstallJob("Feedback Hub")}),
        new("Microsoft Photos", new[] {new UninstallJob("Microsoft Photos")}),
        new("Windows Camera", new[] {new UninstallJob("Windows Camera")}),
        new("Microsoft To Do", new[] {new UninstallJob("Microsoft To Do")}),
        new("Microsoft People", new[] {new UninstallJob("Microsoft People")}),
        new("Solitaire & Casual Games", new[] {new UninstallJob("Solitaire & Casual Games")}),
        new("Mixed Reality Portal", new[] {new UninstallJob("Mixed Reality Portal")}),
        new("Microsoft Sticky Notes", new[] {new UninstallJob("Microsoft Sticky Notes")}),
        new("News", new[] {new UninstallJob("News")}),
        new("Get Help", new[] {new UninstallJob("Get Help")}),
        new("Cortana", new[] {new UninstallJob("Cortana")}),
        new("Power Automate", new[] {new UninstallJob("Power Automate")}),
        new("OneNote for Windows 10", new[] {new UninstallJob("OneNote for Windows 10")}),
        new("Clipchamp", new[] {new UninstallJob("Clipchamp")}),
        new("Windows Web Experience Pack", new[] {new UninstallJob("Windows Web Experience Pack")}),
        new("Paint 3D", new[] {new UninstallJob("Paint 3D")}),
        new("Xbox", new[]
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
        new("Paint", new IJob[]
        {
            new UninstallJob("Paint"),
            new InstallJob("paint.net"),
        }),
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