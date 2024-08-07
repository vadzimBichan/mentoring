using System.Net;
using Epam.ReportPortal.Automation.ApiBusinessLayer;
using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;

public abstract class DashboardApiTestsBase : IDisposable
{
    private readonly string _testName;
    protected DashboardApiSteps DashboardsApiSteps => new(_testName);

    protected DashboardApiTestsBase(string testName)
    {
        _testName = testName;
        CreatedResources.GetResources(testName);
    }

    public void Dispose()
    {
        try
        {
            var dashboardIds = CreatedResources.GetResources(_testName).Dashboards;
            foreach (var dashboardId in dashboardIds)
            {
                var deleteResponse = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
                if (deleteResponse.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"Dashboard with id = '{dashboardId}' was not deleted! Response status code = '{deleteResponse.StatusCode}'.");
                var getResponse = DashboardsApiSteps.GetDashboardRequest(dashboardId);
                if (getResponse.StatusCode != HttpStatusCode.NotFound)
                    throw new Exception($"Dashboard with id = '{dashboardId}' still exists! Response status code = '{getResponse.StatusCode}'.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            CreatedResources.CleanDashboards(_testName);
        }
    }
}