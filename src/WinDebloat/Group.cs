public record Group(string Name, bool IsDefault, IReadOnlyList<IJob> Jobs)
{
    public Group(string name, bool isDefault, IJob job) :
        this(name, isDefault, new[] {job})
    {
    }

    public string Id => Name.Replace(" ", "");

    public bool IsMatch(string exclude) =>
        Id.Equals(exclude, StringComparison.OrdinalIgnoreCase);
}