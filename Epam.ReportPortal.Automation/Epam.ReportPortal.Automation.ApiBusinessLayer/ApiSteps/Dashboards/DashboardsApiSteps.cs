using System.Net;
using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;

public class DashboardsApiSteps : BaseApiSteps
{
    #region Response Steps

    public RestResponse GetAllDashboardsRequest()
    {
        var request = new RestRequest("dashboard");

        return client.Execute(request);
    }

    public RestResponse GetDashboardRequest(int dashboardId)
    {
        var request = new RestRequest($"dashboard/{dashboardId}");

        return client.Execute(request);
    }

    public RestResponse CreateDashboardRequest(string name, string description)
    {
        var request = new RestRequest("dashboard", Method.Post);
        request.AddJsonBody(new
        {
            name,
            description
        });

        return client.Execute(request);
    }

    public RestResponse DeleteDashboardRequest(int dashboardId)
    {
        var request = new RestRequest($"dashboard/{dashboardId}", Method.Delete);

        return client.Execute(request);
    }

    public RestResponse UpdateDashboardRequest(int dashboardId, string name, string description)
    {
        var request = new RestRequest($"dashboard/{dashboardId}", Method.Put);
        request.AddJsonBody(new
        {
            name,
            description
        });

        return client.Execute(request);
    }

    #endregion

    #region Object Steps

    public int CreateDashboard(string name, string description)
    {
        var response = CreateDashboardRequest(name, description);
        var createdDashboardId = JsonConvert.DeserializeObject<DashboardResponseEntities.Id>(response.Content).Value;

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
        var dashboard = JsonConvert.DeserializeObject<DashboardResponseEntities.Dashboard>(response.Content);

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
        var dashboards = JsonConvert.DeserializeObject<DashboardResponseEntities.ResponseBody>(response.Content).Dashboards;

        return dashboards;
    }

    public int GetDashboardsCount()
    {
        return GetDashboardsList().Count;
    }

    public string GetMessageFromResponse(RestResponse response)
    {
        return JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content).Value;
    }

    public DashboardResponseEntities.Message GetErrorFromResponse(RestResponse response)
    {
        return JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content);
    }

    #endregion
}