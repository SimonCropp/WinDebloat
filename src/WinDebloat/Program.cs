using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using System.Management;
using System.ServiceProcess;

public static partial class Program
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
                parseArgument: result => ArgumentParser.ParseExcludes(result, TryFindGroup))
            {
                AllowMultipleArgumentsPerToken = true
            };
            var includeOptions = new Option<string[]>(
                name: "--include",
                description: "Ids of optional items to include.",
                parseArgument: result => ArgumentParser.ParseIncludes(result, TryFindGroup))
            {
                AllowMultipleArgumentsPerToken = true
            };

            var command = new RootCommand();
            command.AddOption(excludeOptions);
            command.AddOption(includeOptions);

            command.SetHandler(
                async (excludes, includes) => await Inner(excludes, includes),
                excludeOptions, includeOptions);

            return await command.InvokeAsync(args);
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

    static bool TryFindGroup(string id, [NotNullWhen(true)] out Group? group)
    {
        group = Groups.SingleOrDefault(_ => _.IsMatch(id));
        return group != null;
    }

    public static async Task Inner(string[] excludes,string[] includes)
    {
        LogExcludes(excludes);
        LogIncludes(includes);

        installed = await WinGet.List();

        services = ServiceController.GetServices();
        foreach (var group in Groups)
        {
            if (group.IsDefault)
            {
                if (excludes.Contains(group.Id, StringComparer.OrdinalIgnoreCase))
                {
                    Log.Information($"Skipping '{group.Name}' since it is excluded");
                    continue;
                }
            }
            else
            {
                if (!includes.Contains(group.Id, StringComparer.OrdinalIgnoreCase))
                {
                    Log.Information($"Skipping '{group.Name}' since it is not included by default an has not been explicitly included");
                    continue;
                }
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

    static void LogIncludes(string[] includes)
    {
        if (!includes.Any())
        {
            return;
        }

        Log.Information("Includes:");
        foreach (var include in includes)
        {
            Log.Information($" * {include}");
        }
    }

    static void LogExcludes(string[] excludes)
    {
        if (!excludes.Any())
        {
            return;
        }

        Log.Information("Excludes:");
        foreach (var exclude in excludes)
        {
            Log.Information($" * {exclude}");
        }
    }

    private static async Task HandleJob(IJob job)
    {
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
            case DisableServiceJob disableServiceJob:
                HandleDisableService(disableServiceJob);
                return;
        }
    }

    static void HandleDisableService(DisableServiceJob job)
    {
        var name = job.Name;
        Log.Information($"DisableService: {name}");
        var service = services.SingleOrDefault(_ => string.Equals(_.ServiceName, name, StringComparison.OrdinalIgnoreCase));
        if (service == null)
        {
            Log.Information($"Skipped disabling service {name} since not installed");
            return;
        }

        if (service.Status == ServiceControllerStatus.Running)
        {
            service.Stop();
        }
        else
        {
            Log.Information($"Skipped stopping service {name} since not running");
        }

        if (service.StartType == ServiceStartMode.Disabled)
        {
            Log.Information($"Skipped disabling service {name} since already disabled");
            return;
        }

        using var managementObject = new ManagementObject($"Win32_Service.Name=\"{name}\"");
        managementObject.InvokeMethod(
            "ChangeStartMode",
            new object[] {"Disabled"});
    }

    static async Task HandleUninstall(UninstallJob job)
    {
        var name = job.Name;
        Log.Information($"Uninstall: {name}");
        if (IsInstalled(name))
        {
            await WinGet.Uninstall(name);
            Log.Information($"Uninstalled {name}");
            return;
        }

        Log.Information($"Skipped uninstall of {name} since not installed");
    }

    static async Task HandleInstall(InstallJob job)
    {
        var name = job.Name;
        Log.Information($"Install: {name}");
        if (IsInstalled(name))
        {
            Log.Information($"Skipped install of {name} since installed");
            return;
        }

        await WinGet.Install(name);
        Log.Information($"Installed {name}");
    }

    static bool IsInstalled(string package) =>
        installed.Any(_ => string.Equals(_, package, StringComparison.OrdinalIgnoreCase));

    static void HandleRegistry(RegistryJob job)
    {
        var (key, name, applyValue, _, kind, _) = job;
        Log.Information($"Registry: {name}");
        Log.Information(@$"{job.Path} to {applyValue}");
        var currentValue = Registry.GetValue(key, name, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information($@"Skipped registry entry {job.Path} since value already correct");
            return;
        }

        Registry.SetValue(key, name, applyValue, kind);
    }

    static List<string> installed = null!;
    static ServiceController[] services = null!;
}