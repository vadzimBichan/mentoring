using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using DashboardResponseEntities = Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities.DashboardResponseEntities;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class DashboardCrudApiTests
{
    public DashboardsApiSteps DashboardsApiSteps => new();

    [Fact]
    public void ItIsPossibleToGetAllDashboards()
    {
        var response = DashboardsApiSteps.GetAllDashboardsRequest();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var dashboards = JsonConvert.DeserializeObject<DashboardResponseEntities.ResponseBody>(response.Content).Dashboards;
        Assert.NotNull(dashboards);
        Assert.True(dashboards.Count > 0);
    }

    [Fact]
    public void ItIsPossibleToGetDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var dashboard = JsonConvert.DeserializeObject<DashboardResponseEntities.Dashboard>(response.Content);
        Assert.NotNull(dashboard);
        Assert.NotEmpty(dashboard.Name);
        Assert.True(dashboard.Name.Length >= 3);
    }

    [Fact]
    public void ItIsPossibleToCreateDashboard()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var createdDashboardId = JsonConvert.DeserializeObject<DashboardResponseEntities.Id>(response.Content).Value;
        Assert.NotNull(createdDashboardId);
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());
    }

    [Fact]
    public void ItIsPossibleToDeleteDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var response = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var message = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully deleted.", message);
        Assert.Equal(dashboards.Count - 1, DashboardsApiSteps.GetDashboardsCount());
    }

    [Fact]
    public void ItIsPossibleToUpdateDashboard()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var newDashboardName = StringUtils.GenerateRandomString(10);
        var newDashboardDescription = StringUtils.GenerateRandomString(10);
        var response = DashboardsApiSteps.UpdateDashboardRequest(dashboardId, newDashboardName, newDashboardDescription);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var message = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully updated", message);
        Assert.Equal(dashboards.Count, DashboardsApiSteps.GetDashboardsCount());

        var updatedDashboard = DashboardsApiSteps.GetDashboardById(dashboardId);
        Assert.Equal(newDashboardName, updatedDashboard.Name);
        Assert.Equal(newDashboardDescription, updatedDashboard.Description);
    }
}
