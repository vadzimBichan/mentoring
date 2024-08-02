using Epam.ReportPortal.Automation.ApiClient.Clients;
using Epam.ReportPortal.Automation.ApiModels.RequestModels;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;

public partial class DashboardApiSteps
{
    private DashboardClient DashboardClient => new();

    public HttpResponseMessage GetAllDashboardsRequest()
    {
        return DashboardClient.GetAllDashboardsRequest();
    }

    public HttpResponseMessage GetDashboardRequest(int dashboardId)
    {
        return DashboardClient.GetDashboardRequest(dashboardId);
    }

    public HttpResponseMessage CreateDashboardRequest(DashboardCreateRequestModel dashboardModel)
    {
        return DashboardClient.CreateDashboardRequest(dashboardModel);
    }

    public HttpResponseMessage DeleteDashboardRequest(int dashboardId)
    {
        return DashboardClient.DeleteDashboardRequest(dashboardId);
    }

    public HttpResponseMessage UpdateDashboardRequest(int dashboardId, DashboardUpdateRequestModel dashboardModel)
    {
        return DashboardClient.UpdateDashboardRequest(dashboardId, dashboardModel);
    }
}