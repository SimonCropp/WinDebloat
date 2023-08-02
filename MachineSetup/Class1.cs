using System.Management;
using System.ServiceProcess;
using CliWrap;
using Microsoft.Win32;
using NUnit.Framework;

[TestFixture]
public class Class1
{
    [Test]
    public async Task Foo()
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
        ForcedPhysicalSectorSizeInBytes();
        InstallDiffEngineTray();
        MakePowerShelUnrestricted();

        await Install("dotPDNLLC.paintdotnet");
        //await Install("Microsoft.SQLServerManagementStudio");
        await Install("ScooterSoftware.BeyondCompare4");
        await UninstallByName("Teams Machine-Wide Installer");
        await UninstallByName("Movies & TV");
        await UninstallByName("Xbox TCUI");
        await UninstallByName("Xbox Console Companion");
        await UninstallByName("Xbox Game Bar Plugin");
        await UninstallByName("Xbox Identity Provider");
        await UninstallByName("Xbox Game Speech Window");
        await UninstallByName("Xbox Game Bar");
        await UninstallByName("Xbox");
        await UninstallByName("Microsoft Tips");
        await UninstallByName("MSN Weather");
        await UninstallByName("Windows Media Player");
        await UninstallByName("Mail and Calendar");
        await UninstallByName("Microsoft Whiteboard");
        await UninstallByName("Microsoft Pay");
        await UninstallByName("Skype");
        await UninstallByName("Windows Maps");
        await UninstallByName("Feedback Hub");
        await UninstallByName("Microsoft Photos");
        await UninstallByName("Windows Camera");
        await UninstallByName("Microsoft To Do");
        await UninstallByName("Microsoft People");
        await UninstallByName("Solitaire & Casual Games");
        await UninstallByName("Mixed Reality Portal");
        await UninstallByName("Microsoft Sticky Notes");
        await UninstallByName("News");
        await UninstallByName("Get Help");
        await UninstallByName("Paint 3D");
        await UninstallByName("Paint");
        await UninstallByName("Cortana");
        await UninstallByName("Clipchamp");

        DisableService("HpTouchpointAnalyticsService");
        DisableService("HPAppHelperCap");
        DisableService("HPDiagsCap");
        DisableService("HPSysInfoCap");
        DisableService("hpsvcsscan");
        DisableService("HotKeyServiceDSU");
        await UninstallByName("HP Notifications");
        await UninstallByName("HP Documentation");
        await UninstallByName("HPHelp");
        await UninstallByName("Power Automate");
        await UninstallByName("OneNote for Windows 10");
        DisableService("Spooler");
        await Upgrade();
    }

    static void InstallDiffEngineTray() =>
        Process.Start("dotnet", "tool install -g DiffEngineTray");

    static void DisableService(string serviceName)
    {
        using (var sc = new ServiceController(serviceName))
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
            }
        }

        using (var m = new ManagementObject($"Win32_Service.Name=\"{serviceName}\""))
        {
            m.InvokeMethod("ChangeStartMode", new object[] {"Disabled"});
        }
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

    //https://learn.microsoft.com/en-us/troubleshoot/sql/database-engine/database-file-operations/troubleshoot-os-4kb-disk-sector-size
    static void ForcedPhysicalSectorSizeInBytes() =>
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\stornvme\Parameters\Device",
            "ForcedPhysicalSectorSizeInBytes",
            new[]{ "* 4095"},
            RegistryValueKind.MultiString);

    static async Task Install(string id)
    {
        Console.WriteLine($"Install {id}");
        var builder = new StringBuilder();
        var arguments = $"install --id {id} --disable-interactivity --exact --no-upgrade  --accept-source-agreements --accept-package-agreements";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (output.Contains("A package version is already installed"))
        {
            Console.WriteLine("  Already installed");
            return;
        }

        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }

    static async Task UninstallById(string id)
    {
        Console.WriteLine($"Uninstall {id}");
        var builder = new StringBuilder();
        var arguments = $"uninstall --id {id} --disable-interactivity --exact";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (output.Contains("No installed package found matching input criteria."))
        {
            Console.WriteLine(output);
            return;
        }

        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }

    static void AppendLine(StringBuilder builder, string line)
    {
        line = line.Trim();
        if (line.Length <= 1)
        {
            return;
        }

        builder.AppendLine(line);
    }

    static async Task UninstallByName(string name)
    {
        Console.WriteLine($"Uninstall {name}");
        var builder = new StringBuilder();
        var arguments = $"uninstall --name \"{name}\" --disable-interactivity --exact";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (output.Contains("No installed package found matching input criteria."))
        {
            Console.WriteLine(output);
            return;
        }

        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }

    static async Task Upgrade()
    {
        Console.WriteLine("upgrade");
        var builder = new StringBuilder();
        var arguments = "upgrade --all";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_ => AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }
}