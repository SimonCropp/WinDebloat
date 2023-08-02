using Microsoft.Win32;
using Serilog;

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

        await WinGet.Uninstall("Teams Machine-Wide Installer");
        await WinGet.Uninstall("Movies & TV");
        await WinGet.Uninstall("Xbox TCUI");
        await WinGet.Uninstall("Xbox Console Companion");
        await WinGet.Uninstall("Xbox Game Bar Plugin");
        await WinGet.Uninstall("Xbox Identity Provider");
        await WinGet.Uninstall("Xbox Game Speech Window");
        await WinGet.Uninstall("Xbox Game Bar");
        await WinGet.Uninstall("Xbox");
        await WinGet.Uninstall("Microsoft Tips");
        await WinGet.Uninstall("MSN Weather");
        await WinGet.Uninstall("Windows Media Player");
        await WinGet.Uninstall("Mail and Calendar");
        await WinGet.Uninstall("Microsoft Whiteboard");
        await WinGet.Uninstall("Microsoft Pay");
        await WinGet.Uninstall("Skype");
        await WinGet.Uninstall("Windows Maps");
        await WinGet.Uninstall("Feedback Hub");
        await WinGet.Uninstall("Microsoft Photos");
        await WinGet.Uninstall("Windows Camera");
        await WinGet.Uninstall("Microsoft To Do");
        await WinGet.Uninstall("Microsoft People");
        await WinGet.Uninstall("Solitaire & Casual Games");
        await WinGet.Uninstall("Mixed Reality Portal");
        await WinGet.Uninstall("Microsoft Sticky Notes");
        await WinGet.Uninstall("News");
        await WinGet.Uninstall("Get Help");
        await WinGet.Uninstall("Paint 3D");
        await WinGet.Uninstall("Paint");
        await WinGet.Install("dotPDNLLC.paintdotnet");
        await WinGet.Uninstall("Cortana");
        await WinGet.Uninstall("Clipchamp");
        await WinGet.Uninstall("Power Automate");
        await WinGet.Uninstall("OneNote for Windows 10");
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