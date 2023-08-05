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
            writer.WriteLine($"### {group.Name}");
            writer.WriteLine();
            if (group.Jobs.Count == 1)
            {
                HandleJob(group.Jobs[0], writer);
                continue;
            }

            foreach (var job in group.Jobs)
            {
                writer.WriteLine($@"#### {job.Name}");
                writer.WriteLine();
                HandleJob(job, writer);
            }
        }
    }

    static void HandleJob(IJob job, TextWriter writer)
    {
        if (job.Notes != null)
        {
            writer.WriteLine("Notes:");
            writer.WriteLine();
            writer.WriteLine(job.Notes);
            writer.WriteLine();
        }

        switch (job)
        {
            case RegistryJob registry:
                writer.WriteLine(
                    $"""
                     Apply:

                     ```ps
                     Set-ItemProperty -Path Registry::{registry.Key} -Name {registry.Name} -Type {registry.Kind} -Value {registry.ApplyValue}
                     ```

                     Revert:

                     ```ps
                     Set-ItemProperty -Path Registry::{registry.Key} -Name {registry.Name} -Type {registry.Kind} -Value {registry.RevertValue}
                     ```
                     """);
                writer.WriteLine();
                return;
            case InstallJob installJob:
                writer.WriteLine(
                    $"""
                     ```ps
                     winget {WinGet.GetInstallArguments(installJob.Name)}
                     ```
                     """);
                writer.WriteLine();
                return;
            case UninstallJob uninstallJob:
                writer.WriteLine(
                    $"""
                     ```ps
                     winget {WinGet.GetUninstallArguments(uninstallJob.Name)}
                     ```
                     """);
                writer.WriteLine();
                return;
        }
    }
}