[TestFixture]
public class ProgramTests
{
    [Test]
    public async Task Full()
    {
        await Program.Inner(Array.Empty<string>());
        foreach (var group in Program.Groups)
        {
            foreach (var job in group.Jobs)
            {
                if (job is RegistryJob registry)
                {
                    var actual = Registry.GetValue(registry.Key, registry.Name, null);

                    if (registry.ApplyValue.Equals(actual))
                    {
                        return;
                    }

                    throw new($@"{registry.Key}\{registry.Name} is {actual} when it should be {registry.ApplyValue}");
                }
            }
        }
    }
}