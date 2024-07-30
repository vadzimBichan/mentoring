using Epam.ReportPortal.Automation.ApiTests.Dashboards.Base;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using DashboardResponseEntities = Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities.DashboardResponseEntities;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class CreateDashboardApiTests: DashboardApiTestsBase
{
    [Fact]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(10);
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
        DashboardsApiSteps.VerifyResponseCode(response, HttpStatusCode.Created);
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

        response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
        DashboardsApiSteps.VerifyResponseCode(response, HttpStatusCode.Conflict);
        Assert.Equal(initialDashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

        var actualMessage = DashboardsApiSteps.GetMessageFromResponse(response);
        Assert.Equal($"Resource '{dashboardName}' already exists. You couldn't create the duplicate.", actualMessage);
    }

    [Theory]
    [InlineData("", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData(" ", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("A", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("AB", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(string dashboardName, string expectedMessage)
    {
        var initialDashboardsCount = DashboardsApiSteps.GetDashboardsCount();
        var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
        DashboardsApiSteps.VerifyResponseCode(response, HttpStatusCode.BadRequest);
        Assert.Equal(initialDashboardsCount, DashboardsApiSteps.GetDashboardsCount());

        var actualMessage = DashboardsApiSteps.GetMessageFromResponse(response);
        Assert.Equal(expectedMessage, actualMessage);
    }
}
