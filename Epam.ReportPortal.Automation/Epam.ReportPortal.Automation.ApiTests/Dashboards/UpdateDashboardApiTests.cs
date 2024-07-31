using System.Net;
using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;
using Epam.ReportPortal.Automation.Core.Utils;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class UpdateDashboardApiTests : DashboardApiTestsBase
{
    [Theory]
    [InlineData("", "[Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData(" ", "[Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("A", "[Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("AB", "[Field 'name' should have size from '3' to '128'.] ")]
    public void ItIsImpossibleToUpdateDashboardNameToHavingLessThanThreeSymbols(string dashboardName, string expectedMessage)
    {
        var initDashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        var initDashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        var dashboardId = DashboardsApiSteps.CreateDashboard(initDashboardName, initDashboardDescription);

        const int expectedErrorCode = 4001;
        var message = DashboardsApiSteps.UpdateDashboardWithError(dashboardId, dashboardName, initDashboardDescription, HttpStatusCode.BadRequest);
        Assert.Contains(expectedMessage, message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
    }

    [Fact]
    public void ItIsImpossibleToUpdateDashboardNameToAlreadyExisting()
    {
        var dashboardName1 = $"DN_{StringUtils.GenerateRandomString(10)}";
        var dashboardName2 = $"DN_{StringUtils.GenerateRandomString(10)}";
        var dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        var dashboardId1 = DashboardsApiSteps.CreateDashboard(dashboardName1, dashboardDescription);
        var dashboardId2 = DashboardsApiSteps.CreateDashboard(dashboardName2, dashboardDescription);

        const int expectedErrorCode = 4091;
        var message = DashboardsApiSteps.UpdateDashboardWithError(dashboardId2, dashboardName1, dashboardDescription, HttpStatusCode.Conflict);
        Assert.Equal($"Resource '{dashboardName1}' already exists. You couldn't create the duplicate.", message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
    }
}