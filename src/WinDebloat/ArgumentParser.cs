using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

public static class ArgumentParser
{
    public delegate bool FindGroup(string id, [NotNullWhen(true)] out Group? group);

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
                errors.Add($"No group found for exclude: {id}");
                continue;
            }

            excludes[index] = id;
        }

        if (errors.Any())
        {
            result.ErrorMessage = string.Join('\n', errors);
        }

        return excludes;
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