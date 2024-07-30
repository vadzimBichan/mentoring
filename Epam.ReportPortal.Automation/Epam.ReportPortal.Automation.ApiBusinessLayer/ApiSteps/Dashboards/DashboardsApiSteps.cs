using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;

public class DashboardsApiSteps : BaseApiSteps
{
    public RestResponse GetAllDashboardsRequest()
    {
        var request = new RestRequest("dashboard", Method.Get);
        return client.Execute(request);
    }

    public RestResponse GetDashboardRequest(int dashboardId)
    {
        var request = new RestRequest($"dashboard/{dashboardId}", Method.Get);
        return client.Execute(request);
    }

    public RestResponse CreateDashboardRequest(string name, string description)
    {
        var request = new RestRequest("dashboard", Method.Post);
        request.AddJsonBody(new {
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

    public DashboardResponseEntities.Dashboard GetDashboardById(int dashboardId)
    {
        var response = GetDashboardRequest(dashboardId);
        var dashboard = JsonConvert.DeserializeObject<DashboardResponseEntities.Dashboard>(response.Content);

        return dashboard;
    }
}