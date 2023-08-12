using System.CommandLine;
using System.CommandLine.Parsing;

public static class ArgumentBuilder
{
    static Func<string[], ArgumentResult> construct;

    static ArgumentBuilder()
    {
        var tokensField = typeof(ArgumentResult).GetField("_tokens", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var constructor = typeof(ArgumentResult).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
            .Single();
        construct = inputs =>
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
        construct(values);
}