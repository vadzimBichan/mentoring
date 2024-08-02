using System.Net;
using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;
using Epam.ReportPortal.Automation.Core.Utils;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class CreateDashboardApiTests : DashboardApiTestsBase
{
    [Fact]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        const int expectedErrorCode = 4091;
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        DashboardsApiSteps.CreateDashboard(dashboardName, "Test Description");
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

        var message = DashboardsApiSteps.CreateDashboardWithError(dashboardName, "Test Description", HttpStatusCode.Conflict);
        Assert.Equal($"Resource '{dashboardName}' already exists. You couldn't create the duplicate.", message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());
    }

    [Theory]
    [InlineData("", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData(" ", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("A", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("AB", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(string dashboardName, string expectedMessage)
    {
        const int expectedErrorCode = 4001;
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var message = DashboardsApiSteps.CreateDashboardWithError(dashboardName, "Test Description", HttpStatusCode.BadRequest);
        Assert.Equal(expectedMessage, message.Value);
        Assert.Equal(expectedErrorCode, message.ErrorCode);
        Assert.Equal(initialDashboardsCount, DashboardsApiSteps.GetDashboardsCount());
    }
}