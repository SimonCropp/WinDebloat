using System.CommandLine;
using System.CommandLine.Parsing;

public static class ArgumentBuilder
{
    static Func<string[], ArgumentResult> constructArgument;

    static ArgumentBuilder()
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

    public static ArgumentResult Build(params string[] values) =>
        constructArgument(values);
}