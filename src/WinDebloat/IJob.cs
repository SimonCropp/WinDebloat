public interface IJob
{
    public string Name { get; }
    public string? Notes { get; }
    string Description { get; }
    Task<JobResult> Run();
}

public record JobResult(bool applied, string? reason);