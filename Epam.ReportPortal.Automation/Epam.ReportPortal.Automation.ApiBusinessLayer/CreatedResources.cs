using System.Collections.Concurrent;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer;

public class CreatedResources
{
    private static readonly ConcurrentDictionary<string, CreatedResources> Instances = new();

    public List<int> Dashboards { get; private set; }

    public static CreatedResources GetResources(string testName)
    {
        return Instances.GetOrAdd(testName, _ => Init());
    }

    private static CreatedResources Init()
    {
        var createdResources = new CreatedResources();
        createdResources.Dashboards = new List<int>();
        return createdResources;
    }

    public static void CleanDashboards(string testName)
    {
        if (Instances.TryRemove(testName, out var createdResources))
            createdResources.Dashboards.Clear();
    }
}