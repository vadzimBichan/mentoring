using System.Net;
using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;
using Epam.ReportPortal.Automation.Core.Utils;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class GetDashboardApiTests : DashboardApiTestsBase
{
    [Fact]
    public void ItIsImpossibleToGetNotExistingDashboard()
    {
        const int expectedErrorCode = 40422;
        var dashboardId = NumericUtils.GetRandomInt(min: 65536);
        var message = DashboardsApiSteps.GetDashboardByIdWithError(dashboardId, HttpStatusCode.NotFound);

        Assert.Contains($"Dashboard with ID '{dashboardId}' not found", message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
    }
}