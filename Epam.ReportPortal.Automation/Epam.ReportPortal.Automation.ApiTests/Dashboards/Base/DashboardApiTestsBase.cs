using System.Net;
using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;

public abstract class DashboardApiTestsBase : IDisposable
{
    protected DashboardsApiSteps DashboardsApiSteps => new();

    public void Dispose()
    {
        try
        {
            var dashboardIds = DashboardsApiSteps.GetDashboardsList().Select(x => x.Id);
            foreach (var dashboardId in dashboardIds)
            {
                var response = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Thread.Sleep(100);
            }

            var maxAttempts = 3;
            var attempt = 0;
            while (DashboardsApiSteps.GetDashboardsCount() > 0 && attempt < maxAttempts)
            {
                Thread.Sleep(1000);
                attempt++;
            }

            if (DashboardsApiSteps.GetDashboardsCount() > 0)
                throw new Exception("Not all dashboards have been successfully removed.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}