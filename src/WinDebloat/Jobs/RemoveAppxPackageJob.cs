public record RemoveAppxPackageJob(
    string PackageName,
    string Name,
    string? Notes = null) :
    IJob
{
    public string Script =>
        $"""
         Get-AppxPackage -AllUsers -Name "{PackageName}" | Remove-AppxPackage -AllUsers
         Get-AppxProvisionedPackage -Online | Where-Object DisplayName -eq "{PackageName}" | Remove-AppxProvisionedPackage -Online
         """;
}
