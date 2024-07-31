using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using DashboardResponseEntities = Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities.DashboardResponseEntities;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;

public class DashboardCrudApiTests
{
    public DashboardsApiSteps DashboardsApiSteps => new();

    public DashboardCrudApiTests()
    {
        var dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        var dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        DashboardsApiSteps.CreateDashboard(dashboardName, dashboardDescription);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToGetAllDashboards()
    {
        var response = DashboardsApiSteps.GetAllDashboardsRequest();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var dashboards = JsonConvert.DeserializeObject<DashboardResponseEntities.ResponseBody>(contentString).Dashboards;
        Assert.NotNull(dashboards);
        Assert.True(dashboards.Count > 0);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToGetDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.Last().Id;
        var response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var dashboard = JsonConvert.DeserializeObject<DashboardResponseEntities.Dashboard>(contentString);
        Assert.NotNull(dashboard);
        Assert.NotEmpty(dashboard.Name);
        Assert.True(dashboard.Name.Length >= 3);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToCreateDashboard()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var createdDashboardId = JsonConvert.DeserializeObject<DashboardResponseEntities.Id>(contentString).Value;
        Assert.True(createdDashboardId > 0);
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToDeleteDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var response = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var message = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully deleted.", message);
        Assert.Equal(dashboards.Count - 1, DashboardsApiSteps.GetDashboardsCount());
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToUpdateDashboard()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var newDashboardName = StringUtils.GenerateRandomString(10);
        var newDashboardDescription = StringUtils.GenerateRandomString(10);
        var response = DashboardsApiSteps.UpdateDashboardRequest(dashboardId, newDashboardName, newDashboardDescription);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var message = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully updated", message);
        Assert.Equal(dashboards.Count, DashboardsApiSteps.GetDashboardsCount());

        var updatedDashboard = DashboardsApiSteps.GetDashboardById(dashboardId);
        Assert.Equal(newDashboardName, updatedDashboard.Name);
        Assert.Equal(newDashboardDescription, updatedDashboard.Description);
    }
}
