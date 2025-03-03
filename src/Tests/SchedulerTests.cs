[TestFixture]
public class SchedulerTests
{
    [Test]
    public void GetTasks()
    {
        var tasks = Scheduler.GetTasks("OneDrive");
        IsNotEmpty(tasks);
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}