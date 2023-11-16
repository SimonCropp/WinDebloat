using System.Diagnostics.CodeAnalysis;

[TestFixture]
[NonParallelizable]
public class CliTests
{
    [TestCaseSource(nameof(GetData))]
    public Task Exclude(FindGroup findGroup)
    {
        var argument = ArgumentBuilder.Build("id");
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
        var argument = ArgumentBuilder.Build("id");
        var includes = ArgumentParser.ParseIncludes(argument, findGroup);

        return Verify(
            new
            {
                includes,
                argument.ErrorMessage
            });
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

    [TestCaseSource(nameof(GetStringParsingData))]
    public async Task Parsing(string[] args, Group[] groups)
    {
        var argValue = string.Join('_', args);
        var groupValue = string.Join(
            '_',
            groups.Select(_ =>
            {
                if (_.IsDefault)
                {
                    return _.Id;
                }

                return $"{_.Id}_optional";
            }));

        var settings = new VerifySettings();
        settings.UseTextForParameters($"Args={argValue}_Groups={groupValue}");

        string[]? receivedExcludes = null;
        string[]? receivedIncludes = null;

        Task Invoke(string[] excludes, string[] includes)
        {
            receivedExcludes = excludes;
            receivedIncludes = includes;
            return Task.CompletedTask;
        }

        await using var writer = new StringWriter();
        Console.SetOut(writer);
        Console.SetError(writer);
        await ArgumentParser.Invoke(
            args,
            Invoke,
            groups);

        await Verify(
            new
            {
                receivedExcludes,
                receivedIncludes,
                console = writer.GetStringBuilder().ToString().Split("Description:").First()
            },
            settings);
    }

    [Test]
    public async Task IncludeAll()
    {
        string[]? receivedExcludes = null;
        string[]? receivedIncludes = null;

        Task Invoke(string[] excludes, string[] includes)
        {
            receivedExcludes = excludes;
            receivedIncludes = includes;
            return Task.CompletedTask;
        }

        await using var writer = new StringWriter();
        Console.SetOut(writer);
        Console.SetError(writer);
        await ArgumentParser.Invoke(
            ["--include-all"],
            Invoke,
            [
                new("one", true, jobs),
                new("two", false, jobs),
            ]);

        await Verify(
            new
            {
                receivedExcludes,
                receivedIncludes,
                console = writer.GetStringBuilder().ToString().Split("Description:").First()
            });
    }

    static InstallJob[] jobs = {new("job")};
    public static IEnumerable<object[]> GetStringParsingData()
    {
        foreach (var arg in new[]
                 {
                     "--include one --exclude two",
                     "--include one",
                     "--include one --exclude one",
                     "--exclude one",
                 })
        {
            var args = arg.Split(' ').ToArray();

            yield return
            [
                args,
                new Group[]
                {
                    new("one", true, jobs),
                    new("two", false, jobs),
                }
            ];
            yield return
            [
                args,
                new Group[]
                {
                    new("one", false, jobs),
                    new("two", true, jobs),
                }
            ];
            foreach (var groupNames in new[]
                     {
                         "one two",
                         "one",
                         "two",
                     })
            {
                var groupIds = groupNames.Split(' ');
                yield return
                [
                    args,
                    groupIds
                        .Select(_ => new Group(_, true, jobs))
                        .ToArray()
                ];
                yield return
                [
                    args,
                    groupIds
                        .Select(_ => new Group(_, false, jobs))
                        .ToArray()
                ];
            }
        }
    }
}