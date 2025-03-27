﻿public static partial class Program
{
    static async Task<int> Main(string[] args)
    {
        Logging.Init();

        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await ArgumentParser.Invoke(args, Inner, Groups);
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
            Log.Information("Time: {ElapsedMilliseconds}ms", stopwatch.ElapsedMilliseconds);
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
                    Log.Information("Skipping '{GroupName}' since it is excluded", group.Name);
                    continue;
                }
            }
            else
            {
                if (!includes.Contains(group.Id, StringComparer.OrdinalIgnoreCase))
                {
                    Log.Information("Skipping '{GroupName}' since it is not included by default and has not been explicitly included", group.Name);
                    continue;
                }
            }

            if (group.Jobs.Count == 1)
            {
                await HandleJob(group.Jobs[0]);
                continue;
            }

            Log.Information("Group: {GroupName}", group.Name);
            foreach (var job in group.Jobs)
            {
                await HandleJob(job);
            }
        }
    }

    static void LogIncludes(string[] includes)
    {
        if (includes.Length == 0)
        {
            return;
        }

        Log.Information("Includes:");
        foreach (var include in includes)
        {
            Log.Information(" * {Include}", include);
        }
    }

    static void LogExcludes(string[] excludes)
    {
        if (excludes.Length == 0)
        {
            return;
        }

        Log.Information("Excludes:");
        foreach (var exclude in excludes)
        {
            Log.Information(" * {Exclude}", exclude);
        }
    }

    static Task HandleJob(IJob job)
    {
        switch (job)
        {
            case RegistryValueJob registry:
                HandleRegistry(registry);
                return Task.CompletedTask;
            case RegistryKeyJob registry:
                HandleRegistry(registry);
                return Task.CompletedTask;
            case InstallJob installJob:
                return HandleInstall(installJob);
            case UninstallJob uninstallJob:
                return HandleUninstall(uninstallJob);
            case EnvironmentVariableJob environmentVariableJob:
                HandleUninstall(environmentVariableJob);
                return Task.CompletedTask;
            case DisableServiceJob disableServiceJob:
                HandleDisableService(disableServiceJob);
                return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }

    static void HandleDisableService(DisableServiceJob job)
    {
        var name = job.Name;
        Log.Information("DisableService: {Name}", name);
        var service = services.SingleOrDefault(_ => string.Equals(_.ServiceName, name, StringComparison.OrdinalIgnoreCase));
        if (service == null)
        {
            Log.Information("Skipped disabling service {Name} since not installed", name);
            return;
        }

        if (service.Status == ServiceControllerStatus.Running)
        {
            service.Stop();
        }
        else
        {
            Log.Information("Skipped stopping service {Name} since not running", name);
        }

        if (service.StartType == ServiceStartMode.Disabled)
        {
            Log.Information("Skipped disabling service {Name} since already disabled", name);
            return;
        }

        using var managementObject = new ManagementObject($"Win32_Service.Name=\"{name}\"");
        managementObject.InvokeMethod("ChangeStartMode", ["Disabled"]);
    }

    static async Task HandleUninstall(UninstallJob job)
    {
        var name = job.Name;
        Log.Information("Uninstall: {Name}", name);
        if (IsInstalled(name, job.PartialMatch))
        {
            await WinGet.Uninstall(name, job.PartialMatch);
            Log.Information("Uninstalled {Name}", name);
            return;
        }

        Log.Information("Skipped uninstall of {Name} since not installed", name);
    }

    static void HandleUninstall(EnvironmentVariableJob job)
    {
        var name = job.Name;
        Log.Information("Setting environment variable: {JobKey} to {JobValue}", job.Key, job.Value);
        Environment.SetEnvironmentVariable(job.Key, job.Value, EnvironmentVariableTarget.Machine);
        Log.Information("Uninstall: {Name}", name);
    }

    static async Task HandleInstall(InstallJob job)
    {
        var name = job.Name;
        Log.Information("Install: {Name}", name);
        if (IsInstalled(name, false))
        {
            Log.Information("Skipped install of {Name} since installed", name);
            return;
        }

        await WinGet.Install(name);
        Log.Information("Installed {Name}", name);
    }

    static bool IsInstalled(string package, bool partialMatch) =>
        installed.Any(_ =>
        {
            if (string.Equals(_, package, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!partialMatch)
            {
                return false;
            }

            if (_.Contains(package, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (_.Replace(" ","").Contains(package, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        });

    static void HandleRegistry(RegistryValueJob job)
    {
        var (key, name, applyValue, _, kind, _) = job;
        Log.Information("Registry: {Name}", name);
        Log.Information("{JobPath} to {ApplyValue}", job.Path, applyValue);
        var currentValue = Registry.GetValue(key, name, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information("Skipped registry entry {JobPath} since value already correct", job.Path);
            return;
        }

        if (name == "(Default)")
        {
            Registry.SetValue(key, null, applyValue, kind);
        }
        else
        {
            Registry.SetValue(key, name, applyValue, kind);
        }
    }

    static void HandleRegistry(RegistryKeyJob job)
    {
        Log.Information("Registry: {JobName}", job.Name);
        Log.Information("{JobKey}", job.Key);

        Registry.SetValue(job.Key, null, "", RegistryValueKind.String);
    }

    static List<string> installed = null!;
    static ServiceController[] services = null!;
}