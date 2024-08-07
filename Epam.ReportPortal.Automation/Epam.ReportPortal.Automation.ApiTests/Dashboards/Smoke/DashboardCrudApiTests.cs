using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using Epam.ReportPortal.Automation.ApiModels.ResponseModels;
using Epam.ReportPortal.Automation.ApiModels.RequestModels;
using Epam.ReportPortal.Automation.ApiBusinessLayer;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Smoke;

public class DashboardCrudApiTests : IDisposable
{
    public DashboardApiSteps DashboardsApiSteps => new(_testName);

    private readonly string _testName;

    public DashboardCrudApiTests()
    {
        _testName = nameof(DashboardCrudApiTests);
        CreatedResources.GetResources(_testName);
        CreateTestDashboard();
        CreateTestDashboard();
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToGetAllDashboards()
    {
        var response = DashboardsApiSteps.GetAllDashboardsRequest();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboards = JsonConvert.DeserializeObject<DashboardGetAllResponseModels>(contentString).Dashboards;
        Assert.NotEmpty(dashboards);
        Assert.True(dashboards.All(x=>x.Name != string.Empty));
        Assert.True(dashboards.All(x => x.Owner != string.Empty));
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToGetDashboardById()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.Last().Id;
        var response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboard = JsonConvert.DeserializeObject<DashboardModel>(contentString);
        Assert.NotNull(dashboard);
        Assert.NotEmpty(dashboard.Name);
        Assert.NotEmpty(dashboard.Description);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToCreateDashboard()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var dashboardDescription = StringUtils.GenerateRandomString(20);
        var dashboardModel = new DashboardCreateRequestModel { Name = dashboardName, Description = dashboardDescription };
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardModel);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var createdDashboardId = JsonConvert.DeserializeObject<IdModel>(contentString).Value;
        CreatedResources.GetResources(_testName).Dashboards.Add(createdDashboardId);

        // check created dashboard details
        var createdDashboard = DashboardsApiSteps.GetDashboardById(createdDashboardId);
        Assert.NotNull(createdDashboard);
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
        var dashboardId = dashboards.Last().Id;
        var response = DashboardsApiSteps.DeleteDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result; ;
        var message = JsonConvert.DeserializeObject<MessageModel>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully deleted.", message);

        // check deleted dashboard details
        response = DashboardsApiSteps.GetDashboardRequest(dashboardId);
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void ItIsPossibleToUpdateDashboard()
    {
        var dashboards = DashboardsApiSteps.GetDashboardsList();
        var dashboardId = dashboards.Last().Id;
        var newDashboardName = StringUtils.GenerateRandomString(10);
        var newDashboardDescription = StringUtils.GenerateRandomString(10);
        var dashboardModel = new DashboardUpdateRequestModel { Name = newDashboardName, Description = newDashboardDescription };
        var response = DashboardsApiSteps.UpdateDashboardRequest(dashboardId, dashboardModel);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var contentString = response.Content.ReadAsStringAsync().Result;
        var message = JsonConvert.DeserializeObject<MessageModel>(contentString).Value;
        Assert.Equal($"Dashboard with ID = '{dashboardId}' successfully updated", message);

        // check updated dashboard details
        var updatedDashboard = DashboardsApiSteps.GetDashboardById(dashboardId);
        Assert.Equal(newDashboardName, updatedDashboard.Name);
        Assert.Equal(newDashboardDescription, updatedDashboard.Description);
        Assert.True(updatedDashboard.Id > 0);
        Assert.Equal("default", updatedDashboard.Owner); // user name
        Assert.Empty(updatedDashboard.Widgets); 
    }

    private void CreateTestDashboard()
    {
        var dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        var dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        DashboardsApiSteps.CreateDashboard(dashboardName, dashboardDescription);
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
                    throw new Exception($"Dashboard with id = '{dashboardId}'still exists! Response status code = '{getResponse.StatusCode}'.");
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
