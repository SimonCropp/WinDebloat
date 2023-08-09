using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

[TestFixture]
public class ArgumentParserTests
{
    static Func<string[], ArgumentResult> constructArgument;

    static ArgumentParserTests()
    {
        var tokensField = typeof(ArgumentResult).GetField("_tokens", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var constructor = typeof(ArgumentResult).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single();
        constructArgument = inputs =>
        {
            var invoke = constructor.Invoke(
                new object?[]
                {
                    new Argument<string[]>(_ => inputs),
                    null
                })!;
            var result = (ArgumentResult) invoke;
            var tokens = (List<Token>) tokensField.GetValue(result)!;
            tokens.AddRange(inputs.Select(_ => new Token(_, TokenType.Argument, null!)));
            return result;
        };
    }


    [TestCaseSource(nameof(GetData))]
    public Task Exclude(FindGroup findGroup)
    {
        var argument = constructArgument(new[] {"id"});
        var excludes = ArgumentParser.ParseExcludes(argument, findGroup);

        return Verify(
                new
                {
                    excludes,
                    argument.ErrorMessage
                });
    }

    [TestCaseSource(nameof(GetData))]
    public Task Include(FindGroup findGroup)
    {
        var argument = constructArgument(new[] {"id"});
        var includes = ArgumentParser.ParseIncludes(argument, findGroup);

        return Verify(
                new
                {
                    includes,
                    argument.ErrorMessage
                })
            .UseTextForParameters(findGroup.Method.Name);
    }

    public static IEnumerable<object[]> GetData()
    {
        foreach (var findGroup in new FindGroup[] {FoundDefault, FoundNonDefault, NotFound})
        {
            yield return new object[] {findGroup};
        }
    }

    static bool FoundDefault(string id, [NotNullWhen(true)] out Group? group)
    {
        group = new("goodId", true, new UninstallJob("app"));
        return true;
    }

    static bool FoundNonDefault(string id, [NotNullWhen(true)] out Group? group)
    {
        group = new("goodId", false, new UninstallJob("app"));
        return true;
    }

    static bool NotFound(string id, [NotNullWhen(true)] out Group? group)
    {
        group = null;
        return false;
    }
}