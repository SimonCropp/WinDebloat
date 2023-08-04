public interface IJob
{
    public string Name { get; }
    public string? Notes { get; }
    string Description { get; }
    void Assert();
    void Run();
}