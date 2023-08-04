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
                job.Assert();
            }
        }
    }
}