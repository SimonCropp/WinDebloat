#if DEBUG
[TestFixture]
public class ProgramTests
{
    [Test]
    [Explicit]
    public async Task Full()
    {
        await Program.Inner(
            Array.Empty<string>(),
            Program.Groups.Where(_ => !_.IsDefault)
            .Select(_ => _.Id)
            .ToArray());

        foreach (var group in Program.Groups)
        {
            foreach (var job in group.Jobs)
            {
                if (job is not RegistryValueJob registryJob)
                {
                    continue;
                }

                var actual = Registry.GetValue(registryJob.Key, registryJob.Name, null);

                if (registryJob.ApplyValue.Equals(actual))
                {
                    return;
                }

                throw new($@"{registryJob.Key}\{registryJob.Name} is {actual} when it should be {registryJob.ApplyValue}");
            }
        }
    }
}
#endif