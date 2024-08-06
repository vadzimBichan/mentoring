using System.Collections.Concurrent;
using NUnit.Framework;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public class CreatedResources
{
    private static readonly ConcurrentDictionary<string, CreatedResources> Instances = new();

    public List<int> Dashboards { get; private set; }

    public static CreatedResources GetResources()
    {
        return Instances.GetOrAdd(TestContext.CurrentContext.Test.FullName, _ => Init());
    }

    private static CreatedResources Init()
    {
        var createdResources = new CreatedResources();
        createdResources.Dashboards = new List<int>();
        return createdResources;
    }

    public static void CleanDashboards()
    {
        if (Instances.TryRemove(TestContext.CurrentContext.Test.FullName, out var createdResources))
            createdResources.Dashboards.Clear();
    }
}