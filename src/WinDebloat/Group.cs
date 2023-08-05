public record Group(string Name, IReadOnlyList<IJob> Jobs)
{
    public Group(string name, IJob job) :
        this(name, new[] {job})
    {
    }

    public string Id => Name.Replace(" ", "");

    public bool IsMatch(string exclude) =>
        Id.Equals(exclude, StringComparison.OrdinalIgnoreCase);
}