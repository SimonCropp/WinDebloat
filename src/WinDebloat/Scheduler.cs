public static class Scheduler
{
    public static List<string> GetTasks(string prefix)
    {
        using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\TaskCache\Tree");
        return GetTasks(key, prefix).ToList();
    }

    private static IEnumerable<string> GetTasks(RegistryKey? key, string prefix)
    {
        if (key == null)
        {
            yield break;
        }

        foreach (var name in key.GetSubKeyNames())
        {
            if (name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                yield return name;
            }

            using var subKey = key.OpenSubKey(name);
            foreach (var subName in GetTasks(subKey, prefix))
            {
                yield return subName;
            }
        }
    }
}