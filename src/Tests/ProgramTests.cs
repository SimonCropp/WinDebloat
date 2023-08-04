[TestFixture]
public class ProgramTests
{
    [Test]
    public async Task Full()
    {
        await Program.Inner();
        foreach (var group in Program.Groups)
        {
            foreach (var job in group.Jobs)
            {
                if (job is RegistryJob registryJob)
                {
                    var actual = Registry.GetValue(registryJob.Key, registryJob.Name, null);

                    if (registryJob.Value.Equals(actual))
                    {
                        return;
                    }

                    throw new($@"{registryJob.Key}\{registryJob.Name} is {actual} when it should be {registryJob.Value}");
                }
            }
        }
    }
}