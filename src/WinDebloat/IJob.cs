public interface IJob
{
    public string Name { get; }
    string Description { get; }
    void Assert();
    void Run();
}