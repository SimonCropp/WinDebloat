using System.Text;
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
        RemoveChat();
        RemoveTaskBarSearch();
        RemoveWidgets();
        RemoveTaskView();
        EnableDeveloperMode();
        await Install("dotPDNLLC.paintdotnet");
        await Install("SublimeHQ.SublimeText.4");
        await UninstallByName("Teams Machine-Wide Installer");
        await UninstallByName("Movies & TV");
        await UninstallByName("Xbox TCUI");
        await UninstallByName("Xbox Console Companion");
        await UninstallByName("Xbox Game Bar Plugin");
        await UninstallByName("Xbox Identity Provider");
        await UninstallByName("Xbox Game Speech Window");
        await UninstallByName("Xbox Game Bar");
        await UninstallById("Microsoft.GamingApp_8wekyb3d8bbwe");
        await UninstallByName("Phone Link");
        await UninstallByName("Microsoft Tips");
        await UninstallByName("MSN Weather");
        await UninstallByName("Windows Media Player");
        await UninstallByName("Geekbench 6");
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
        await UninstallByName("Clipchamp");
        await UninstallByName("Cortana");
        await UninstallByName("HP Notifications");
        await UninstallByName("Power Automate");
        await UninstallByName("OneNote for Windows 10");
        
    }

    static void RemoveChat()
    {
        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn", 0);
    }

    static void RemoveWidgets()
    {
        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarDa", 0);
    }

    static void RemoveTaskView()
    {
        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 0);
    }
    static void RemoveTaskBarSearch()
    {
        Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode", 0);
    }
    static void EnableDeveloperMode()
    {
        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx","AllowDevelopmentWithoutDevLicense", 1);
    }
    
    private static async Task Install(string id)
    {
        Console.WriteLine($"Install {id}");
        var builder = new StringBuilder();
        var arguments = $"install --id {id} --disable-interactivity --exact --no-upgrade";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
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

    private static async Task UninstallById(string id)
    {
        Console.WriteLine($"Uninstall {id}");
        var builder = new StringBuilder();
        var arguments = $"uninstall --id {id} --disable-interactivity --exact";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (output.Contains("No installed package found matching input criteria."))
        {
            Console.WriteLine(  output);
            return;
        }

        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }

    private static void AppendLine(StringBuilder builder, string line)
    {
        line = line.Trim();
        if (line.Length <= 1)
        {
            return;
        }

        builder.AppendLine(line);
    }

    private static async Task UninstallByName(string name)
    {
        Console.WriteLine($"Uninstall {name}");
        var builder = new StringBuilder();
        var arguments = $"uninstall --name \"{name}\" --disable-interactivity --exact";
        var commandResult = await Cli.Wrap("winget")
            .WithArguments(arguments)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_=> AppendLine(builder, _)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();
        var output = builder.ToString();
        if (output.Contains("No installed package found matching input criteria."))
        {
            Console.WriteLine(  output);
            return;
        }

        if (commandResult.ExitCode != 0)
        {
            throw new(output);
        }
    }
}