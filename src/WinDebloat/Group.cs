public record Group(string Name, IReadOnlyList<IJob> Jobs)
{
    public Group(string name, IJob job) : this(name, new []{job}) { }
}