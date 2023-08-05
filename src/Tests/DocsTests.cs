[TestFixture]
public class DocsTests
{
    [Test]
    public void Full()
    {
        var md = Path.Combine(AttributeReader.GetSolutionDirectory(), @"actions.include.md");
        File.Delete(md);
        using var writer = File.CreateText(md);
        foreach (var group in Program.Groups)
        {
            writer.WriteLine(
                $"""
                 ### {group.Name}

                 Id to toggle behavior: `{group.Id}`

                 """);
            if (group.Jobs.Count == 1)
            {
                HandleJob(group.Jobs[0], writer);
                continue;
            }

            foreach (var job in group.Jobs)
            {
                writer.WriteLine(
                    $"""
                     #### {job.Name}

                     """);
                HandleJob(job, writer);
            }

            writer.WriteLine();
        }
    }

    static void HandleJob(IJob job, TextWriter writer)
    {
        switch (job)
        {
            case RegistryJob(var key, var name, var applyValue, var revertValue, var kind, _):
                writer.WriteLine(
                    $"""
                     Command to manually apply:

                     ```ps
                     Set-ItemProperty -Path Registry::{key} -Name {name} -Type {kind} -Value {applyValue}
                     ```

                     Command to manually revert:

                     ```ps
                     Set-ItemProperty -Path Registry::{key} -Name {name} -Type {kind} -Value {revertValue}
                     ```

                     """);
                break;
            case InstallJob installJob:
                writer.WriteLine(
                    $"""
                     Installs `{installJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).
                     
                     Command to manually apply:

                     ```ps
                     winget install --name "{installJob.Name}" --exact
                     ```

                     """);
                break;
            case UninstallJob uninstallJob:
                writer.WriteLine(
                    $"""
                     Uninstalls `{uninstallJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

                     Command to manually apply:

                     ```ps
                     winget uninstall --name "{uninstallJob.Name}" --exact
                     ```

                     """);
                break;
        }
        if (job.Notes != null)
        {
            writer.WriteLine(
                $"""
                 Notes:

                 {job.Notes}
                
                 """);
        }
        writer.WriteLine();
    }
}