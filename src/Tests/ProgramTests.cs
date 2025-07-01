#if DEBUG
[TestFixture]
public class ProgramTests
{
    [Test]
    [Explicit]
    public async Task Full()
    {
        await Program.Inner(
            [],
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

                var actual = Registry.GetValue(registryJob.Key, registryJob.KeyName, null);

                if (registryJob.ApplyValue.Equals(actual))
                {
                    return;
                }

                throw new($@"{registryJob.Key}\{registryJob.KeyName} is {actual} when it should be {registryJob.ApplyValue}");
            }
        }
    }
}
#endif