using System.Net;
using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;

public class DashboardsApiSteps : BaseApiSteps
{
    #region Response Steps

    public HttpResponseMessage GetAllDashboardsRequest()
    {
        return client.GetAsync("api/v1/default_personal/dashboard").Result;
    }

    public HttpResponseMessage GetDashboardRequest(int dashboardId)
    {
        return client.GetAsync($"api/v1/default_personal/dashboard/{dashboardId}").Result;
    }

    public HttpResponseMessage CreateDashboardRequest(string name, string description)
    {
        var obj = new
        {
            name,
            description
        };

        return client.PostAsync("api/v1/default_personal/dashboard", obj).Result;
    }

    public HttpResponseMessage DeleteDashboardRequest(int dashboardId)
    {
        return client.DeleteAsync($"api/v1/default_personal/dashboard/{dashboardId}").Result;
    }

    public HttpResponseMessage UpdateDashboardRequest(int dashboardId, string name, string description)
    {
        var obj = new
        {
            name,
            description
        };

        return client.PutAsync($"api/v1/default_personal/dashboard/{dashboardId}", obj).Result;
    }

    #endregion

    #region Object Steps

    public int CreateDashboard(string name, string description)
    {
        var response = CreateDashboardRequest(name, description);
        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var createdDashboardId = JsonConvert.DeserializeObject<DashboardResponseEntities.Id>(contentString).Value;

        return createdDashboardId;
    }

    public DashboardResponseEntities.Message CreateDashboardWithError(string name, string description, HttpStatusCode expectedStatusCode)
    {
        var response = CreateDashboardRequest(name, description);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public string DeleteDashboard(int dashboardId)
    {
        var response = DeleteDashboardRequest(dashboardId);

        return GetMessageFromResponse(response);
    }

    public DashboardResponseEntities.Message DeleteDashboardWithError(int dashboardId, HttpStatusCode expectedStatusCode)
    {
        var response = DeleteDashboardRequest(dashboardId);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public string UpdateDashboard(int dashboardId, string name, string description)
    {
        var response = UpdateDashboardRequest(dashboardId, name, description);
        return GetMessageFromResponse(response);
    }

    public DashboardResponseEntities.Message UpdateDashboardWithError(int dashboardId, string name, string description, HttpStatusCode expectedStatusCode)
    {
        var response = UpdateDashboardRequest(dashboardId, name, description);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public DashboardResponseEntities.Dashboard GetDashboardById(int dashboardId)
    {
        var response = GetDashboardRequest(dashboardId);
        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var dashboard = JsonConvert.DeserializeObject<DashboardResponseEntities.Dashboard>(contentString);

        return dashboard;
    }

    public DashboardResponseEntities.Message GetDashboardByIdWithError(int dashboardId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var response = GetDashboardRequest(dashboardId);
        VerifyResponseCode(response, expectedStatusCode);

        return GetErrorFromResponse(response);
    }

    public List<DashboardResponseEntities.Dashboard> GetDashboardsList()
    {
        var response = GetAllDashboardsRequest();
        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var dashboards = JsonConvert.DeserializeObject<DashboardResponseEntities.ResponseBody>(contentString).Dashboards;

        return dashboards;
    }

    public int GetDashboardsCount()
    {
        return GetDashboardsList().Count;
    }

    public string GetMessageFromResponse(HttpResponseMessage response)
    {
        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(contentString).Value;
    }

    public DashboardResponseEntities.Message GetErrorFromResponse(HttpResponseMessage response)
    {
        var contentString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(contentString);
    }

    #endregion
}