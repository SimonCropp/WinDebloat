using System.CommandLine;
using System.CommandLine.Parsing;

public static class Program
{
    static async Task<int> Main(string[] args)
    {
        Logging.Init();

        var stopwatch = Stopwatch.StartNew();
        try
        {
            var excludeOptions = new Option<string[]>(
                name: "--exclude",
                description: "Ids of items to exclude.",
                parseArgument: ParseExcludes)
            {
                AllowMultipleArgumentsPerToken = true
            };

            var rootCommand = new RootCommand();
            rootCommand.AddOption(excludeOptions);

            rootCommand.SetHandler(
                async excludes => await Inner(excludes),
                excludeOptions);

            return await rootCommand.InvokeAsync(args);
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

    static string[] ParseExcludes(ArgumentResult result)
    {
        var excludes = new string[result.Tokens.Count];
        for (var index = 0; index < result.Tokens.Count; index++)
        {
            var token = result.Tokens[index];
            var value = token.Value;
            if (!Groups.Any(_ => _.IsMatch(value)))
            {
                result.ErrorMessage = $"No group found for exclude: {value}";
                return Array.Empty<string>();
            }

            excludes[index] = value;
        }

        return excludes;
    }

    public static async Task Inner(string[] excludes)
    {
        if (excludes.Any())
        {
            Log.Information("Excludes:");
            foreach (var exclude in excludes)
            {
                Log.Information($" * {exclude}");
            }
        }

        installed = await WinGet.List();
        foreach (var group in Groups)
        {
            if (excludes.Contains(group.Id, StringComparer.OrdinalIgnoreCase))
            {
                Log.Information($"Skipping '{group.Name}' since it is excluded");
                continue;
            }

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
        switch (job)
        {
            case RegistryJob registry:
                Log.Information($"Registry: {job.Name}");
                HandleRegistry(registry);
                return;
            case InstallJob installJob:
                Log.Information($"Install: {job.Name}");
                await HandleInstall(installJob);
                return;
            case UninstallJob uninstallJob:
                Log.Information($"Uninstall: {job.Name}");
                await HandleUninstall(uninstallJob);
                return;
        }
    }

    static async Task HandleUninstall(UninstallJob uninstall)
    {
        if (IsInstalled(uninstall.Name))
        {
            await WinGet.Uninstall(uninstall.Name);
            Log.Information($"Uninstalled {uninstall.Name}");
            return;
        }

        Log.Information($"Skipped uninstall of {uninstall.Name} since not installed");
    }

    static async Task HandleInstall(InstallJob install)
    {
        if (IsInstalled(install.Name))
        {
            Log.Information($"Skipped install of {install.Name} since installed");
            return;
        }

        await WinGet.Install(install.Name);
        Log.Information($"Installed {install.Name}");
    }

    static bool IsInstalled(string package) =>
        installed.Any(_ => string.Equals(_, package, StringComparison.OrdinalIgnoreCase));

    static void HandleRegistry(RegistryJob registry)
    {
        var (key, name, applyValue, _, kind, _) = registry;
        Log.Information(@$"{registry.Path} to {applyValue}");
        var currentValue = Registry.GetValue(key, name, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information($@"Skipped registry entry {registry.Path} since value already correct");
            return;
        }

        Registry.SetValue(key, name, applyValue, kind);
    }

    public static List<Group> Groups = new()
    {
        new(
            "Advertiser Id",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
                "Enabled",
                0,
                1,
                Notes: " * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)")),
        new("Camera", new UninstallJob("Windows Camera")),
        new(
            "Chat",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarMn",
                0,
                1)),
        new("Clipchamp", new UninstallJob("Clipchamp")),
        new("Cortana", new UninstallJob("Cortana")),
        new(
            "DeveloperMode",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
                "AllowDevelopmentWithoutDevLicense",
                1,
                0,
                Notes: " * https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development")),
        new(
            "EdgeDesktopSearchBar",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "WebWidgetAllowed",
                0,
                1)),
        new("Feedback Hub", new UninstallJob("Feedback Hub")),
        new(
            "FileExtensions",
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "HideFileExt",
                0,
                1)),
        new("Games", new UninstallJob("Solitaire & Casual Games")),
        new("Get Help", new UninstallJob("Get Help")),
        new(
            "Lock Screen Ads",
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
        new("Mail and Calendar", new UninstallJob("Mail and Calendar")),
        new("Maps", new UninstallJob("Windows Maps")),
        new("Media Player", new UninstallJob("Windows Media Player")),
        new("Mixed Reality Portal", new UninstallJob("Mixed Reality Portal")),
        new("Movies and TV", new UninstallJob("Movies & TV")),
        new("News", new UninstallJob("News")),
        new("OneNote", new UninstallJob("OneNote for Windows 10")),
        new("Pay", new UninstallJob("Microsoft Pay")),
        new("Paint", new IJob[]
        {
            new UninstallJob("Paint"),
            new InstallJob("paint.net"),
        }),
        new("People", new UninstallJob("Microsoft People")),
        new("Photos", new UninstallJob("Microsoft Photos")),
        new("Power Automate", new UninstallJob("Power Automate")),
        new(
            "PowerShelUnrestricted",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell",
                "ExecutionPolicy",
                "Unrestricted",
                RegistryValueKind.String)),
        new("Paint 3D", new UninstallJob("Paint 3D")),
        new("Skype", new UninstallJob("Skype")),
        new(
            "StartupBoost",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge",
                "StartupBoostEnabled",
                0,
                1)),
        new(
            "Start Menu Recommendations",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "HideRecommendedSection",
                1,
                0)),
        new("Sticky Notes", new UninstallJob("Microsoft Sticky Notes")),
        new(
            "TaskBarSearch",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                "SearchboxTaskbarMode",
                0,
                1)),
        new(
            "Task View",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowTaskViewButton",
                0,
                1)),
        new("Teams", new UninstallJob("Teams Machine-Wide Installer")),
        new(
            "Telemetry",
            new RegistryJob(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                "Allow Telemetry",
                0,
                1)),
        new("Tips", new UninstallJob("Microsoft Tips")),
        new("To Do", new UninstallJob("Microsoft To Do")),
        new("Weather", new UninstallJob("MSN Weather")),
        new("Web Experience Pack", new UninstallJob("Windows Web Experience Pack")),
        new(
            "WebSearch",
            new RegistryJob(
                @"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer",
                "DisableSearchBoxSuggestions",
                1,
                0)),
        new("Whiteboard", new UninstallJob("Microsoft Whiteboard")),
        new(
            "Widgets",
            new RegistryJob(
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "TaskbarDa",
                0,
                1)),
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
    };

    static List<string> installed = null!;
}