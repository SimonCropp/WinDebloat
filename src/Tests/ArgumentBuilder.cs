using System.CommandLine;
using System.CommandLine.Parsing;

public static class ArgumentBuilder
{
    public static ArgumentResult Build(params string[] values)
    {
        var argument = new Argument<string[]>("test");
        var command = new RootCommand { argument };

        var parseResult = command.Parse(values);
        return parseResult.GetResult(argument)!;
    }
}