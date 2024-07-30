using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;

public abstract class DashboardApiTestsBase
{
    protected DashboardsApiSteps DashboardsApiSteps => new();
}