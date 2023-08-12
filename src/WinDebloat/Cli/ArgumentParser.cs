using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

public static class ArgumentParser
{
    public static async Task<int> Invoke(string[] args, InvokeAction invoke, IReadOnlyCollection<Group> groups)
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

        var includeOptions = new Option<string[]>(
            name: "--include",
            description: "Ids of optional items to include.",
            parseArgument: result => ParseIncludes(result, FindGroup))
        {
            AllowMultipleArgumentsPerToken = true
        };

        var command = new RootCommand
        {
            excludeOptions,
            includeOptions
        };

        command.SetHandler(
            async (excludes, includes) => await invoke(excludes, includes),
            excludeOptions,
            includeOptions);

        return await command.InvokeAsync(args);
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
        if (errors.Any())
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