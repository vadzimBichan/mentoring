using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Dashboards;
using Epam.ReportPortal.Automation.ApiTests.Base;
using Epam.ReportPortal.Automation.Core.Utils;
using Newtonsoft.Json;
using System.Net;
using Xunit.Abstractions;
using DashboardResponseEntities = Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps.Entities.DashboardResponseEntities;


namespace Epam.ReportPortal.Automation.ApiTests.Dashboards;

public class DashboardApiTests : ReportPortalApiTestsBase
{
    public DashboardsApiSteps DashboardsApiSteps => new();

    public DashboardApiTests(ITestOutputHelper output) : base(output) { }

    [Theory, MemberData(nameof(AllowedLengthData))]
    public void ItIsPossibleToCreateDashboardWithUniqueName(int dashboardNameLength)
    {
        RunTest(() =>
        {
            var initialdashboardsCount = DashboardsApiSteps.GetDashboardsCount();
            var dashboardName = StringUtils.GenerateRandomString(dashboardNameLength);
            var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(initialdashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

            int createdDashboardId = JsonConvert.DeserializeObject<DashboardResponseEntities.Id>(response.Content).Value;
            var createdDashboard = DashboardsApiSteps.GetDashboardById(createdDashboardId);
            Assert.Equal(dashboardName, createdDashboard.Name);
        });
    }

    [Fact]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        RunTest(() =>
        {
            var initialdashboardsCount = DashboardsApiSteps.GetDashboardsCount();
            var dashboardName = StringUtils.GenerateRandomString(10);
            var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(initialdashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

            response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.Equal(initialdashboardsCount + 1, DashboardsApiSteps.GetDashboardsCount());

            var message = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content).Value;
            Assert.Equal($"Resource '{dashboardName}' already exists. You couldn't create the duplicate.", message);
        });
    }

    [Theory]
    [InlineData("", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData(" ", "Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("A", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    [InlineData("AB", "Incorrect Request. [Field 'name' should have size from '3' to '128'.] ")]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(string dashboardName, string expectedMessage)
    {
        RunTest(() =>
        {
            var initialdashboardsCount = DashboardsApiSteps.GetDashboardsCount();
            var response = DashboardsApiSteps.CreateDashboardRequest(dashboardName, "Test Description");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(initialdashboardsCount, DashboardsApiSteps.GetDashboardsCount());

            var actualMessage = JsonConvert.DeserializeObject<DashboardResponseEntities.Message>(response.Content).Value;
            Assert.Equal(expectedMessage, actualMessage);
        });
    }

    public static IEnumerable<object[]> AllowedLengthData => new List<object[]>
    {
        new object[] { 3 },
        new object[] { 128 }
    };
}
