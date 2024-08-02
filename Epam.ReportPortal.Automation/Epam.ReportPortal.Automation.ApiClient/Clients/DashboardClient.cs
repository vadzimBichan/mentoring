using Epam.ReportPortal.Automation.ApiModels.RequestModels;

namespace Epam.ReportPortal.Automation.ApiClient.Clients;

public class DashboardClient : BaseClient
{
    public HttpResponseMessage GetAllDashboardsRequest()
    {
        return Client.GetAsync("api/v1/default_personal/dashboard").Result;
    }

    public HttpResponseMessage GetDashboardRequest(int dashboardId)
    {
        return Client.GetAsync($"api/v1/default_personal/dashboard/{dashboardId}").Result;
    }

    public HttpResponseMessage CreateDashboardRequest(DashboardCreateRequestModel dashboardModel)
    {
        return Client.PostAsync("api/v1/default_personal/dashboard", dashboardModel).Result;
    }

    public HttpResponseMessage DeleteDashboardRequest(int dashboardId)
    {
        return Client.DeleteAsync($"api/v1/default_personal/dashboard/{dashboardId}").Result;
    }

    public HttpResponseMessage UpdateDashboardRequest(int dashboardId, DashboardUpdateRequestModel dashboardModel)
    {
        return Client.PutAsync($"api/v1/default_personal/dashboard/{dashboardId}", dashboardModel).Result;
    }
}