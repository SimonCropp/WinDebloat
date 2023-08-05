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
            if (group.Jobs.Count == 1)
            {
                await HandleJob(group.Jobs[0]);
                continue;
            }

            Log.Information($"Group: {group.Name}");
            foreach (var job in group.Jobs)
            {
                await HandleJob(job);
            }
        }
    }

    private static async Task HandleJob(IJob job)
    {
        Log.Information($"  Job: {job.Name}");
        switch (job)
        {
            case RegistryJob registry:
                HandleRegistry(registry);
                return;
            case InstallJob installJob:
                await HandleInstall(installJob);
                return;
            case UninstallJob uninstallJob:
                await HandleUninstall(uninstallJob);
                return;
        }
    }

    static async Task HandleUninstall(UninstallJob uninstall)
    {
        if (IsInstalled(uninstall.Name))
        {
            await WinGet.Install(uninstall.Name);
            Log.Information("    Uninstalled");
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
        Log.Information("    Installed");
    }

    static bool IsInstalled(string package) =>
        installed.Any(_ => string.Equals(_, package, StringComparison.OrdinalIgnoreCase));

    static void HandleRegistry(RegistryJob registry)
    {
        var (key, name, applyValue, _, kind, _) = registry;
        Log.Information(@$"    Registry: {key}\{name} to {applyValue} ({kind})");
        var currentValue = Registry.GetValue(key, name, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information($"      Skipped since value is already {applyValue}");
            return;
        }

        Registry.SetValue(key, name, applyValue, kind);
    }

    public static List<Group> Groups = new()
    {
        new("Teams Machine-Wide Installer", new UninstallJob("Teams Machine-Wide Installer")),
        new("Movies & TV", new UninstallJob("Movies & TV")),
        new("Microsoft Tips", new UninstallJob("Microsoft Tips")),
        new("MSN Weather", new UninstallJob("MSN Weather")),
        new("Windows Media Player", new UninstallJob("Windows Media Player")),
        new("Mail and Calendar", new UninstallJob("Mail and Calendar")),
        new("Microsoft Whiteboard", new UninstallJob("Microsoft Whiteboard")),
        new("Microsoft Pay", new UninstallJob("Microsoft Pay")),
        new("Skype", new UninstallJob("Skype")),
        new("Windows Maps", new UninstallJob("Windows Maps")),
        new("Feedback Hub", new UninstallJob("Feedback Hub")),
        new("Microsoft Photos", new UninstallJob("Microsoft Photos")),
        new("Windows Camera", new UninstallJob("Windows Camera")),
        new("Microsoft To Do", new UninstallJob("Microsoft To Do")),
        new("Microsoft People", new UninstallJob("Microsoft People")),
        new("Solitaire & Casual Games", new UninstallJob("Solitaire & Casual Games")),
        new("Mixed Reality Portal", new UninstallJob("Mixed Reality Portal")),
        new("Microsoft Sticky Notes", new UninstallJob("Microsoft Sticky Notes")),
        new("News", new UninstallJob("News")),
        new("Get Help", new UninstallJob("Get Help")),
        new("Cortana", new UninstallJob("Cortana")),
        new("Power Automate", new UninstallJob("Power Automate")),
        new("OneNote for Windows 10", new UninstallJob("OneNote for Windows 10")),
        new("Clipchamp", new UninstallJob("Clipchamp")),
        new("Windows Web Experience Pack", new UninstallJob("Windows Web Experience Pack")),
        new("Paint 3D", new UninstallJob("Paint 3D")),
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
                    0,
                    1),
                new RegistryJob(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
                    "SubscribedContent-338387Enabled",
                    0,
                    1),
            }),
        new(
            "RemoveChat",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0,
                1)),
        new(
            "DisableTelemetry",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                "Allow Telemetry",
                0,
                1)),
        new(
            "DisableAdvertiserId",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                "Enabled",
                0,
                1)),
        new(
            "RemoveWidgets",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0,
                1)),
        new(
            "HideStartMenuRecommendedSection",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "HideRecommendedSection",
                1,
                0)),
        new(
            "DisableStartupBoost",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0,
                1)),
        new(
            "RemoveTaskView",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0,
                1)),
        new(
            "RemoveTaskBarSearch",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                "SearchboxTaskbarMode",
                0,
                1)),
        new(
            "EnableFileExtensions",
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0,
                1)),
        new(
            "EnableDeveloperMode",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
                "AllowDevelopmentWithoutDevLicense",
                1,
                0,
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
                1,
                0)),
        new(
            "DisableEdgeDesktopSearchBar",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "WebWidgetAllowed",
                0,
                1)),
    };

    static List<string> installed = null!;
}