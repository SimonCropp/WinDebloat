[TestFixture]
public class DocsTests
{
    [Test]
    public void Full()
    {
        var md = Path.Combine(AttributeReader.GetSolutionDirectory(), "actions.include.md");
        File.Delete(md);

        using var writer = File.CreateText(md);

        writer.WriteLine(
            """
            ## Items DeBloated

            """);

        foreach (var group in Program.Groups)
        {
            if (group.IsDefault)
            {
                writer.WriteLine($" * {group.Name}");
            }
            else
            {
                writer.WriteLine($" * {group.Name} (optional)");
            }
        }

        writer.WriteLine(
            """

            
            ## Default Items Removed / Disabled


            """);

        foreach (var group in Program.Groups.Where(_ => _.IsDefault))
        {
            WriteGroup(writer, group);
        }

        writer.WriteLine(
            """
            ## Optional Items Removed / Disabled


            """);
        foreach (var group in Program.Groups.Where(_ => !_.IsDefault))
        {
            WriteGroup(writer, group);
        }
    }

    static void WriteGroup(StreamWriter writer, Group group)
    {
        writer.WriteLine(
            $"""
             ### {group.Name}
             
             """);
        if (group.IsDefault)
        {
            writer.WriteLine(
                $"""
                 Id to exclude: `{group.Id}`

                 """);
        }
        else
        {
            writer.WriteLine(
                $"""
                 Id to include: `{group.Id}`

                 """);
        }

        if (group.Jobs.Count == 1)
        {
            HandleJob(group.Jobs[0], writer);
            return;
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

    static void HandleJob(IJob job, TextWriter writer)
    {
        switch (job)
        {
            case DisableServiceJob disableServiceJob:
                writer.WriteLine(
                    $"""
                     Command to manually apply:

                     ```ps
                     Stop-Service -Name "{disableServiceJob.Name}"
                     Set-Service -Name "{disableServiceJob.Name}"`
                                 -StartupType "Disabled"
                     ```

                     Command to manually revert:

                     ```ps
                     Set-Service -Name "{disableServiceJob.Name}"`
                                 -StartupType "Automatic"
                     Start-Service -Name "{disableServiceJob.Name}"
                     ```

                     """);
                break;
            case RegistryJob registryJob:
                writer.WriteLine(
                    $"""
                     Command to manually apply:

                     ```ps
                     Set-ItemProperty -Path "Registry::{registryJob.ShortKey}"`
                                      -Name "{registryJob.Name}"`
                                      -Type "{registryJob.Kind}"`
                                      -Value "{registryJob.ApplyValue}"
                     ```

                     Command to manually revert:

                     ```ps
                     Set-ItemProperty -Path "Registry::{registryJob.ShortKey}"`
                                      -Name "{registryJob.Name}"`
                                      -Type "{registryJob.Kind}"`
                                      -Value "{registryJob.RevertValue}"
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