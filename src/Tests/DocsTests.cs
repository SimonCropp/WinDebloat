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
        }
    }

    static void HandleJob(IJob job, TextWriter writer)
    {

        switch (job)
        {
            case RegistryJob registry:
                writer.WriteLine(
                    $"""
                     Command to manually apply:

                     ```ps
                     Set-ItemProperty -Path Registry::{registry.Key} -Name {registry.Name} -Type {registry.Kind} -Value {registry.ApplyValue}
                     ```

                     Command to manually revert:

                     ```ps
                     Set-ItemProperty -Path Registry::{registry.Key} -Name {registry.Name} -Type {registry.Kind} -Value {registry.RevertValue}
                     ```
                     """);
                writer.WriteLine();
                return;
            case InstallJob installJob:
                writer.WriteLine(
                    $"""
                     Install `{installJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).
                     
                     Command to manually apply:

                     ```ps
                     winget install --name "{installJob.Name}" --exact
                     ```
                     """);
                writer.WriteLine();
                return;
            case UninstallJob uninstallJob:
                writer.WriteLine(
                    $"""
                     Uninstall `{uninstallJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

                     Command to manually apply:

                     ```ps
                     winget uninstall --name "{uninstallJob.Name}" --exact
                     ```
                     """);
                writer.WriteLine();
                return;
        }
        if (job.Notes != null)
        {
            writer.WriteLine(
                $"""

                 Notes:

                 {job.Notes}
                
                 """);
        }
    }
}