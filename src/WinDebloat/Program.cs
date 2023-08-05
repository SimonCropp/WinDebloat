using System.CommandLine;
using System.Diagnostics.CodeAnalysis;

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
                async (excludes,includes) => await Inner(excludes,includes),
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

    static List<string> installed = null!;
}