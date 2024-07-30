using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class DeleteDashboardApiTests : DashboardApiTestsBase
{
    [Fact]
    public void ItIsImpossibleToDeleteDashboardTwoTimes()
    {
        //var dashboardId = DashboardsApiSteps.CreateDashboard("TestDashboard");
        //DashboardsApiSteps.DeleteDashboard(dashboardId);
        //Assert.False(DashboardsApiSteps.IsDashboardExists(dashboardId));
    }

    [Fact]
    public void ItIsImpossibleToDeleteNotExistingDashboard()
    {
        //var dashboardId = DashboardsApiSteps.CreateDashboard("TestDashboard");
        //DashboardsApiSteps.DeleteDashboard(dashboardId);
        //Assert.False(DashboardsApiSteps.IsDashboardExists(dashboardId));
    }
}