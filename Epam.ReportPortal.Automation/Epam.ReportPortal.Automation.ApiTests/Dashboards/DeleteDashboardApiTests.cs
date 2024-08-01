using System.Net;
using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;
using Epam.ReportPortal.Automation.Core.Utils;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class DeleteDashboardApiTests : DashboardApiTestsBase
{
    [Fact]
    public void ItIsImpossibleToDeleteDashboardTwoTimes()
    {
        const int expectedErrorCode = 40422;
        var dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        var dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        var dashboardId = DashboardsApiSteps.CreateDashboard(dashboardName, dashboardDescription);
        Assert.NotNull(DashboardsApiSteps.GetDashboardById(dashboardId));

        var successfulMessage = DashboardsApiSteps.DeleteDashboard(dashboardId);
        Assert.Contains($"Dashboard with ID = '{dashboardId}' successfully deleted", successfulMessage);
        Assert.Contains(dashboardId.ToString(), successfulMessage);

        var negativeMessage = DashboardsApiSteps.DeleteDashboardWithError(dashboardId, HttpStatusCode.NotFound);
        Assert.Contains($"Dashboard with ID '{dashboardId}' not found", negativeMessage.Value);
        Assert.Equal(expectedErrorCode, negativeMessage.ErrorCode);
    }

    [Fact]
    public void ItIsImpossibleToDeleteNotExistingDashboard()
    {
        const int expectedErrorCode = 40422;
        var dashboardId = NumericUtils.GetRandomInt(min: 65536);
        var message = DashboardsApiSteps.DeleteDashboardWithError(dashboardId, HttpStatusCode.NotFound);

        Assert.Contains($"Dashboard with ID '{dashboardId}' not found", message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
    }
}