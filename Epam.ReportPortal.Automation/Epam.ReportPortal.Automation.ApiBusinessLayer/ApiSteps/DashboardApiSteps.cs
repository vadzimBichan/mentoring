using System.Net;
using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using Epam.ReportPortal.Automation.ApiModels.RequestModels;
using Epam.ReportPortal.Automation.ApiModels.ResponseModels;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;

public partial class DashboardApiSteps : BaseApiSteps
{
    public DashboardApiSteps(string testName) : base(testName)
    {
    }

    public int CreateDashboard(string name, string description)
    {
        var dashboardModel = new DashboardCreateRequestModel { Name = name, Description = description };
        var response = CreateDashboardRequest(dashboardModel);
        var contentString = response.Content.ReadAsStringAsync().Result;
        var createdDashboardId = JsonConvert.DeserializeObject<IdModel>(contentString).Value;
        CreatedResources.GetResources(TestName).Dashboards.Add(createdDashboardId);

        return createdDashboardId;
    }

    public ErrorMessageModel CreateDashboardWithError(string name, string description, HttpStatusCode expectedStatusCode)
    {
        var dashboardModel = new DashboardCreateRequestModel { Name = name, Description = description };
        var response = CreateDashboardRequest(dashboardModel);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public string DeleteDashboard(int dashboardId)
    {
        var response = DeleteDashboardRequest(dashboardId);

        return GetMessageFromResponse(response);
    }

    public ErrorMessageModel DeleteDashboardWithError(int dashboardId, HttpStatusCode expectedStatusCode)
    {
        var response = DeleteDashboardRequest(dashboardId);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public string UpdateDashboard(int dashboardId, string name, string description)
    {
        var dashboardModel = new DashboardUpdateRequestModel { Name = name, Description = description };
        var response = UpdateDashboardRequest(dashboardId, dashboardModel);

        return GetMessageFromResponse(response);
    }

    public ErrorMessageModel UpdateDashboardWithError(int dashboardId, string name, string description, HttpStatusCode expectedStatusCode)
    {
        var dashboardModel = new DashboardUpdateRequestModel { Name = name, Description = description };
        var response = UpdateDashboardRequest(dashboardId, dashboardModel);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public DashboardModel GetDashboardById(int dashboardId)
    {
        var response = DashboardClient.GetDashboardRequest(dashboardId);
        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboard = JsonConvert.DeserializeObject<DashboardModel>(contentString);

        return dashboard;
    }

    public ErrorMessageModel GetDashboardByIdWithError(int dashboardId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var response = DashboardClient.GetDashboardRequest(dashboardId);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public List<DashboardModel> GetDashboardsList()
    {
        var response = DashboardClient.GetAllDashboardsRequest();
        var contentString = response.Content.ReadAsStringAsync().Result;
        var dashboards = JsonConvert.DeserializeObject<DashboardGetAllResponseModels>(contentString).Dashboards;

        return dashboards;
    }
}