public record Group(string Name, string Id, bool IsDefault, IReadOnlyList<IJob> Jobs)
{
    public Group(string name, string id, bool isDefault, IJob job) :
        this(name, id, isDefault, [job])
    {
    }

    public Group(string name, bool isDefault, IReadOnlyList<IJob> jobs) :
        this(name, name.Replace(" ", ""), isDefault, jobs)
    {
    }
    public Group(string name, bool isDefault, IJob job) :
        this(name, name.Replace(" ", ""), isDefault, [job])
    {
    }

    public bool IsMatch(string exclude) =>
        Id.Equals(exclude, StringComparison.OrdinalIgnoreCase);
}