static class Program
{
    static async Task Main()
    {
        Logging.Init();

        try
        {
            await Inner();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Failed at startup");
            throw;
        }
    }

    static async Task Inner()
    {
        //https://winget.run
        //https://github.com/valinet/ExplorerPatcher
        RemoveChat();
        DisableStartupBoost();
        RemoveTaskBarSearch();
        RemoveWidgets();
        RemoveTaskView();
        EnableDeveloperMode();
        DisableWebSearch();
        MakePowerShelUnrestricted();

        await WinGet.UninstallByName("Teams Machine-Wide Installer");
        await WinGet.UninstallByName("Movies & TV");
        await WinGet.UninstallByName("Xbox TCUI");
        await WinGet.UninstallByName("Xbox Console Companion");
        await WinGet.UninstallByName("Xbox Game Bar Plugin");
        await WinGet.UninstallByName("Xbox Identity Provider");
        await WinGet.UninstallByName("Xbox Game Speech Window");
        await WinGet.UninstallByName("Xbox Game Bar");
        await WinGet.UninstallByName("Xbox Accessories");
        await WinGet.UninstallByName("Xbox");
        await WinGet.UninstallByName("Microsoft Tips");
        await WinGet.UninstallByName("MSN Weather");
        await WinGet.UninstallByName("Windows Media Player");
        await WinGet.UninstallByName("Mail and Calendar");
        await WinGet.UninstallByName("Microsoft Whiteboard");
        await WinGet.UninstallByName("Microsoft Pay");
        await WinGet.UninstallByName("Skype");
        await WinGet.UninstallByName("Windows Maps");
        await WinGet.UninstallByName("Feedback Hub");
        await WinGet.UninstallByName("Microsoft Photos");
        await WinGet.UninstallByName("Windows Camera");
        await WinGet.UninstallByName("Microsoft To Do");
        await WinGet.UninstallByName("Microsoft People");
        await WinGet.UninstallByName("Solitaire & Casual Games");
        await WinGet.UninstallByName("Mixed Reality Portal");
        await WinGet.UninstallByName("Microsoft Sticky Notes");
        await WinGet.UninstallByName("News");
        await WinGet.UninstallByName("Get Help");
        await WinGet.UninstallByName("Paint 3D");
        await WinGet.UninstallByName("Paint");
        await WinGet.InstallById("dotPDNLLC.paintdotnet");
        await WinGet.UninstallByName("Cortana");
        await WinGet.UninstallByName("Clipchamp");
        await WinGet.UninstallByName("Power Automate");
        await WinGet.UninstallByName("OneNote for Windows 10");
    }

    static void RemoveChat() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "TaskbarMn",
            0);

    static void RemoveWidgets() =>
        Registry.SetValue(
            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "TaskbarDa",
            0);

    static void DisableStartupBoost() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge", "StartupBoostEnabled",
            1,
            RegistryValueKind.DWord);

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

    //https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development
    static void EnableDeveloperMode() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx",
            "AllowDevelopmentWithoutDevLicense",
            1,
            RegistryValueKind.DWord);

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
            1,
            RegistryValueKind.DWord);
}