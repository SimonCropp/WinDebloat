using System.CommandLine;
using System.CommandLine.Parsing;

public static class ArgumentParser
{
    public static Task<int> Invoke(string[] args, InvokeAction invoke, IReadOnlyCollection<Group> groups)
    {
        bool FindGroup(string id, [NotNullWhen(true)] out Group? group) =>
            TryFindGroup(id, groups, out group);

        var excludeOptions = new Option<string[]>(
            name: "--exclude",
            description: "Ids of items to exclude.",
            parseArgument: result => ParseExcludes(result, FindGroup))
        {
            AllowMultipleArgumentsPerToken = true
        };

        var defaults = groups.Where(_ => _.IsDefault).Select(_ => _.Id).ToArray();
        excludeOptions.AddCompletions(defaults);

        var includeOptions = new Option<string[]>(
            name: "--include",
            description: "Ids of optional items to include.",
            parseArgument: result => ParseIncludes(result, FindGroup))
        {
            AllowMultipleArgumentsPerToken = true
        };
        var optionals = groups.Where(_ => !_.IsDefault).Select(_ => _.Id).ToArray();
        includeOptions.AddCompletions(optionals);

        var includeAllOptions = new Option<bool>(
            name: "--include-all",
            description: "include all optional items.");

        var command = new RootCommand
        {
            excludeOptions,
            includeOptions,
            includeAllOptions
        };

        command.SetHandler(async (excludes, includes, includeAll) =>
            {
                try
                {
                    if (includeAll)
                    {
                        await invoke(
                            [],
                            groups.Where(_ => !_.IsDefault)
                                .Select(_ => _.Id)
                                .ToArray());
                        return;
                    }

                    await invoke(excludes, includes);
                }
                catch (WinGetNotInstalledException)
                {
                    Log.Fatal($"WinGet not installed. Expected path: {WinGet.ExpectedPath}. To install: https://www.microsoft.com/p/app-installer/9nblggh4nns1");

                    if (Environment.UserInteractive)
                    {
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                    }
                }
                catch (WinGetVersionNotMetException exception)
                {
                    Log.Fatal($"WinGet version is incorrect. Minimum: {WinGet.MinVersion}. Installed: {exception.InstalledVersion}. Releases: https://github.com/microsoft/winget-cli/releases");

                    if (Environment.UserInteractive)
                    {
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                    }
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "Failed invoking command");
                    throw;
                }
            },
            excludeOptions,
            includeOptions,
            includeAllOptions);

        return command.InvokeAsync(args);
    }

    static bool TryFindGroup(string id, IEnumerable<Group> groups, [NotNullWhen(true)] out Group? group)
    {
        group = groups.SingleOrDefault(_ => _.IsMatch(id));
        return group != null;
    }

    public static string[] ParseExcludes(ArgumentResult result, FindGroup findGroup)
    {
        var values = result.Values();
        var excludes = new string[values.Length];
        var errors = new List<string>();
        for (var index = 0; index < values.Length; index++)
        {
            var id = values[index];
            if (!findGroup(id, out var group))
            {
                errors.Add($"No item found for exclude: {id}");
                continue;
            }

            if (!group.IsDefault)
            {
                errors.Add($"Item is not include by default: {id}");
                continue;
            }

            excludes[index] = id;
        }

        SetErrorMessage(result, errors);

        return excludes;
    }

    public static string[] ParseIncludes(ArgumentResult result, FindGroup findGroup)
    {
        var values = result.Values();
        var includes = new string[values.Length];
        var errors = new List<string>();
        for (var index = 0; index < values.Length; index++)
        {
            var id = values[index];
            if (!findGroup(id, out var group))
            {
                errors.Add($"No item found for include: {id}");
                continue;
            }

            if (group.IsDefault)
            {
                errors.Add($"Item is already includes: {id}");
                continue;
            }

            includes[index] = id;
        }

        SetErrorMessage(result, errors);

        return includes;
    }

    static void SetErrorMessage(ArgumentResult result, List<string> errors)
    {
        if (errors.Count != 0)
        {
            result.ErrorMessage = string.Join('\n', errors);
        }
    }

    static string[] Values(this ArgumentResult result)
    {
        var tokens = result.Tokens;

        var items = new string[result.Tokens.Count];
        for (var index = 0; index < result.Tokens.Count; index++)
        {
            items[index] = tokens[index].Value;
        }

        return items;
    }
}