using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using Epam.ReportPortal.Automation.ApiModels.ResponseModels;
using Epam.ReportPortal.Automation.ApiModels.RequestModels;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Smoke;

public class DashboardCrudApiTests
{
    public DashboardApiSteps DashboardsApiSteps => new();

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

        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboards = JsonConvert.DeserializeObject<DashboardGetAllResponseModels>(contentString).Dashboards;
        Assert.True(dashboards.Count > 0);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToGetDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboard = JsonConvert.DeserializeObject<DashboardModel>(contentString);
        Assert.True(dashboard.Name.Length >= 3);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToCreateDashboard()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var dashboardDescription = StringUtils.GenerateRandomString(20);
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var dashboardModel = new DashboardCreateRequestModel { Name = dashboardName, Description = dashboardDescription };
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardModel);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var createdDashboardId = JsonConvert.DeserializeObject<IdModel>(contentString).Value;
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

        // check created dashboard details
        var createdDashboard = DashboardsApiSteps.GetDashboardById(createdDashboardId);
        Assert.Equal(dashboardName, createdDashboard.Name);
        Assert.Equal(dashboardDescription, createdDashboard.Description);
        Assert.Equal(createdDashboardId, createdDashboard.Id);
        Assert.Equal("default", createdDashboard.Owner); // user name
        Assert.Empty(createdDashboard.Widgets);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToDeleteDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var response = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result; ;
        var message = JsonConvert.DeserializeObject<MessageModel>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully deleted.", message);
        Assert.Equal(dashboards.Count - 1, DashboardsApiSteps.GetDashboardsCount());

        // check deleted dashboard details
        response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToUpdateDashboard()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.First().Id;
        var newDashboardName = StringUtils.GenerateRandomString(10);
        var newDashboardDescription = StringUtils.GenerateRandomString(10);
        var dashboardModel = new DashboardUpdateRequestModel { Name = newDashboardName, Description = newDashboardDescription };
        var response = DashboardsApiSteps.UpdateDashboardRequest(dashboardId, dashboardModel);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var message = JsonConvert.DeserializeObject<MessageModel>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully updated", message);
        Assert.Equal(dashboards.Count, DashboardsApiSteps.GetDashboardsCount());

        // check updated dashboard details
        var updatedDashboard = DashboardsApiSteps.GetDashboardById(dashboardId);
        Assert.Equal(newDashboardName, updatedDashboard.Name);
        Assert.Equal(newDashboardDescription, updatedDashboard.Description);
        Assert.True(updatedDashboard.Id > 0);
        Assert.Equal("default", updatedDashboard.Owner); // user name
        Assert.Empty(updatedDashboard.Widgets); 
    }
}
