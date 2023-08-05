using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

[TestFixture]
public class ArgumentParserTests
{
    static Func<string[], ArgumentResult> constructArgument;

    static ArgumentParserTests()
    {
        var tokensField = typeof(ArgumentResult).GetField("_tokens",BindingFlags.NonPublic | BindingFlags.Instance)!;
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
            var tokens = (List<Token>)tokensField.GetValue(result)!;
            tokens.AddRange(inputs.Select(_=>new Token(_, TokenType.Argument, null!)));
            return result;
        };
    }

    [Test]
    public Task ExcludeEmpty()
    {
        var argumentResult = constructArgument(Array.Empty<string>());
        var excludes = ArgumentParser.ParseExcludes(argumentResult, FoundDefault);

        return Verify(
            new
            {
                excludes,
                argumentResult.ErrorMessage
            });
    }

    [Test]
    public Task ExcludeMatch()
    {
        var argumentResult = constructArgument(new []{"theId"});
        var excludes = ArgumentParser.ParseExcludes(argumentResult, FoundDefault);

        return Verify(
            new
            {
                excludes,
                argumentResult.ErrorMessage
            });
    }
    [Test]
    public Task ExcludeMisMatch()
    {
        var argumentResult = constructArgument(new []{"badId"});
        var excludes = ArgumentParser.ParseExcludes(argumentResult, NotFound);

        return Verify(
            new
            {
                excludes,
                argumentResult.ErrorMessage
            });
    }

    static bool FoundDefault(string id, [NotNullWhen(true)] out Group? group)
    {
        group = new("theId", true, new UninstallJob("app"));
        return true;
    }


    static bool FoundNonDefault(string id, [NotNullWhen(true)] out Group? group)
    {
        group = new("theId", false, new UninstallJob("app"));
        return true;
    }

    static bool NotFound(string id, [NotNullWhen(true)] out Group? group)
    {
        group = null;
        return false;
    }
}