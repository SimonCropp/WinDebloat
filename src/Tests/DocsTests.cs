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
            var id = group
                .Name.ToLower()
                .Replace(' ', '-');
            if (group.IsDefault)
            {
                writer.WriteLine($" * [{group.Name}](#{id})");
            }
            else
            {
                writer.WriteLine($" * [{group.Name}](#{id}) (optional)");
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
            HandleJob(group.Jobs[0], writer, "####");
            return;
        }

        foreach (var job in group.Jobs)
        {
            writer.WriteLine(
                $"""
                 #### {job.Name}

                 """);
            HandleJob(job, writer, "#####");
        }

        writer.WriteLine();
    }

    static void HandleJob(IJob job, TextWriter writer, string headingLevel)
    {
        switch (job)
        {
            case DisableServiceJob disableServiceJob:
                writer.WriteLine(
                    $"""
                     {headingLevel} Command to manually apply:

                     ```ps
                     Stop-Service -Name "{disableServiceJob.Name}"
                     Set-Service -Name "{disableServiceJob.Name}"`
                                 -StartupType "Disabled"
                     ```

                     {headingLevel} Command to manually revert:

                     ```ps
                     Set-Service -Name "{disableServiceJob.Name}"`
                                 -StartupType "Automatic"
                     Start-Service -Name "{disableServiceJob.Name}"
                     ```

                     """);
                break;
            case RegistryValueJob registryJob:
                writer.WriteLine(
                    $"""
                     {headingLevel} Command to manually apply:

                     ```ps
                     Set-ItemProperty -Path "Registry::{registryJob.ShortKey}"`
                                      -Name "{registryJob.Name}"`
                                      -Type "{registryJob.Kind}"`
                                      -Value "{registryJob.ApplyValue}"
                     ```

                     {headingLevel} Command to manually revert:

                     """);
                if (registryJob.RevertValue is null)
                {
                    writer.WriteLine(
                        $"""
                         ```ps
                         Remove-ItemProperty -Path "Registry::{registryJob.ShortKey}"`
                                             -Name "{registryJob.Name}"
                         ```

                         """);
                }
                else
                {
                    writer.WriteLine(
                        $"""
                         ```ps
                         Set-ItemProperty -Path "Registry::{registryJob.ShortKey}"`
                                          -Name "{registryJob.Name}"`
                                          -Type "{registryJob.Kind}"`
                                          -Value "{registryJob.RevertValue}"
                         ```

                         """);
                }

                break;
            case RegistryKeyJob registryJob:
            {
                if (registryJob.Invert)
                {
                    writer.WriteLine(
                        $"""
                         {headingLevel} Command to manually apply:
                         
                         ```ps
                         Remove-Item -Path "Registry::{registryJob.ShortKey}"
                         ```

                         {headingLevel} Command to manually revert:
                         
                         ```ps
                         New-Item -Path "Registry::{registryJob.ShortKey}" -Value ""
                         ````

                         """);
                }
                else
                {
                    writer.WriteLine(
                        $"""
                         {headingLevel} Command to manually apply:

                         ```ps
                         New-Item -Path "Registry::{registryJob.ShortKey}" -Value ""
                         ````

                         {headingLevel} Command to manually revert:

                         ```ps
                         Remove-Item -Path "Registry::{registryJob.ShortKey}"
                         ```

                         """);
                }
            }
                break;
            case InstallJob installJob:
                writer.WriteLine(
                    $"""
                     Installs `{installJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

                     {headingLevel} Command to manually apply:

                     ```ps
                     winget install --name "{installJob.Name}" --exact
                     ```

                     """);
                break;
            case UninstallJob uninstallJob:

                string command;

                if (uninstallJob.PartialMatch)
                {
                    command = $"""
                               winget uninstall "{uninstallJob.Name}"
                               """;
                }
                else
                {
                    command = $"""winget uninstall --name "{uninstallJob.Name}" --exact""";
                }

                writer.WriteLine(
                    $"""
                     Uninstalls `{uninstallJob.Name}` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

                     {headingLevel} Command to manually apply:

                     ```ps
                     {command}
                     ```

                     """);
                break;
            case EnvironmentVariableJob environmentVariableJob:

                writer.WriteLine(
                    $"""
                      Sets environment variable `{environmentVariableJob.Key}` to `{environmentVariableJob.Value}`.

                      {headingLevel} Command to manually apply:

                      ```ps
                      $env:{environmentVariableJob.Key} = "{environmentVariableJob.Value}";
                      ```

                      """);
                break;
        }

        if (job.Notes != null)
        {
            writer.WriteLine(
                $"""
                 {headingLevel} Notes:

                 {job.Notes}

                 """);
        }

        writer.WriteLine();
    }
}