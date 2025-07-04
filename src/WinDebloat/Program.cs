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
                break;
            case RegistryKeyJob registry:
                HandleRegistry(registry);
                break;
            case InstallByNameJob installByNameJob:
                return HandleInstall(installByNameJob);
            case InstallByIdJob installByIdJob:
                return HandleInstall(installByIdJob);
            case UninstallByNameJob uninstallByNameJob:
                return HandleUninstall(uninstallByNameJob);
            case UninstallByIdJob uninstallByIdJob:
                return HandleUninstall(uninstallByIdJob);
            case EnvironmentVariableJob environmentVariableJob:
                HandleUninstall(environmentVariableJob);
                break;
            case DisableServiceJob disableServiceJob:
                HandleDisableService(disableServiceJob);
                break;
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

    static async Task HandleUninstall(UninstallByNameJob job)
    {
        var name = job.Name;
        Log.Information("Uninstall: {Name}", name);
        if (IsInstalledByName(name))
        {
            await WinGet.UninstallByName(name);
            Log.Information("Uninstalled {Name}", name);
            return;
        }

        Log.Information("Skipped uninstall of {Name} since not installed", name);
    }
    static async Task HandleUninstall(UninstallByIdJob job)
    {
        var name = job.Name;
        Log.Information("Uninstall: {Name}", name);
        if (IsInstalledById(name))
        {
            await WinGet.UninstallById(name);
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

    static async Task HandleInstall(InstallByNameJob job)
    {
        var name = job.Name;
        Log.Information("Install: {Name}", name);
        if (IsInstalledByName(name))
        {
            Log.Information("Skipped install of {Name} since installed", name);
            return;
        }

        await WinGet.InstallByName(name);
        Log.Information("Installed {Name}", name);
    }

    static async Task HandleInstall(InstallByIdJob job)
    {
        var name = job.Name;
        Log.Information("Install: {Name}", name);
        if (IsInstalledById(name))
        {
            Log.Information("Skipped install of {Name} since installed", name);
            return;
        }

        await WinGet.InstallById(name);
        Log.Information("Installed {Name}", name);
    }

    static bool IsInstalledByName(string package) =>
        installed.Any(_ => string.Equals(_.name, package, StringComparison.OrdinalIgnoreCase));

    static bool IsInstalledById(string package) =>
        installed.Any(_ => string.Equals(_.id, package, StringComparison.OrdinalIgnoreCase));

    public static void HandleRegistry(RegistryValueJob job)
    {
        var (hive, key, keyName, applyValue, _, name, kind, _) = job;
        Log.Information("Registry: {Name}", name);
        Log.Information("{JobHive} {JobPath} to {ApplyValue}", hive, key, applyValue);
        using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default);
        using var subKey = baseKey.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
        var currentValue = subKey.GetValue(keyName, null);
        if (applyValue.Equals(currentValue))
        {
            Log.Information("Skipped registry entry {JobHive} {JobPath} since value already correct", hive, key);
            return;
        }

        if (keyName == "(Default)")
        {
            subKey.SetValue(null, applyValue, kind);
        }
        else
        {
            subKey.SetValue(keyName, applyValue, kind);
        }
    }

    static void HandleRegistry(RegistryKeyJob job)
    {
        Log.Information("Registry: {JobName}", job.Name);
        if (job.Invert)
        {
            Log.Information("Remove {JobKey}", job.Key);

            using var baseKey = RegistryKey.OpenBaseKey(job.Hive, RegistryView.Default);
            baseKey.DeleteSubKey(job.Key, false);
        }
        else
        {
            Log.Information("Add {JobKey}", job.Key);

            using var baseKey = RegistryKey.OpenBaseKey(job.Hive, RegistryView.Default);
            using var subKey = baseKey.CreateSubKey(job.Key, RegistryKeyPermissionCheck.ReadWriteSubTree);
            subKey.SetValue(null, "", RegistryValueKind.String);
        }
    }

    static List<(string name, string id)> installed = null!;
    static ServiceController[] services = null!;
}