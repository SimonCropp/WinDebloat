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
            return await ArgumentParser.Invoke(args, async (excludes, includes) => await Inner(excludes, includes), Groups);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Failed at startup");

            if (Environment.UserInteractive)
            {
                Console.ReadLine();
            }

            throw;
        }
        finally
        {
            Log.Information($"Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public static async Task Inner(string[] excludes, string[] includes)
    {
        WinGet.EnsureInstalled();
        await WinGet.EnsureVersion();
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
                    Log.Information($"Skipping '{group.Name}' since it is not included by default and has not been explicitly included");
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

    static async Task HandleJob(IJob job)
    {
        switch (job)
        {
            case RegistryValueJob registry:
                HandleRegistry(registry);
                return;
            case RegistryKeyJob registry:
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

    static void HandleRegistry(RegistryValueJob job)
    {
        var (key, name, applyValue, _, kind, _) = job;
        Log.Information($"Registry: {name}");
        Log.Information($"{job.Path} to {applyValue}");
        var currentValue = Registry.GetValue(key, name, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information($"Skipped registry entry {job.Path} since value already correct");
            return;
        }

        Registry.SetValue(key, name, applyValue, kind);
    }

    static void HandleRegistry(RegistryKeyJob job)
    {
        Log.Information($"Registry: {job.Name}");
        Log.Information($"{job.Key}");

        Registry.SetValue(job.Key, null, "", RegistryValueKind.String);
    }

    static List<string> installed = null!;
    static ServiceController[] services = null!;
}