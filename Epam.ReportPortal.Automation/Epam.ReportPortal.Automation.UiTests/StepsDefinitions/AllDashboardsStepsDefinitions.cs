using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using TechTalk.SpecFlow.Assist;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions;

[Binding]
public sealed class AllDashboardsStepsDefinitions
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();

    private readonly ScenarioContext _scenarioContext;

    public AllDashboardsStepsDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"New dashboard is created with properties and opened")]
    [Given(@"Additional dashboard is created with properties and opened")]
    public void GivenNewDashboardIsCreatedWithPropertiesAndOpened(Table table)
    {
        var fields = table.CreateInstance<(string Name, string Description)>();

        var dashboardId = AllDashboardsSteps.CreateDashboard(fields.Name, fields.Description);

        var dashboardIds = _scenarioContext.Get<List<int>>("DashboardIDs");
        dashboardIds.Add(dashboardId);
        _scenarioContext["DashboardIDs"] = dashboardIds;
    }

    [When(@"User navigates to All Dashboards Page")]
    public void WhenUserNavigatesToAllDashboardsPage()
    {
        AllDashboardsSteps.OpenAllDashboardsPage();
    }

    [Then(@"Dashboard with name '([^']*)' and description '([^']*)' exists in the table on All Dashboards Page")]
    public void ThenDashboardWithNameAndDescriptionExistsInTheTableOnAllDashboardsPage(string dashboardName, string dashboardDescription)
    {
        var dashboards = AllDashboardsSteps.GetDashboards();

        Assert.That(
            dashboards.Count(x => x.Name == dashboardName && x.Description == dashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is EXPECTED to have dashboard with name = '{dashboardName}' and description = '{dashboardDescription}'1");
    }

    [Then(@"Dashboard with name '([^']*)' and description '([^']*)' does NOT exist in the table on All Dashboards Page")]
    public void ThenDashboardWithNameAndDescriptionDoesNOTExistInTheTableOnAllDashboardsPage(string dashboardName, string dashboardDescription)
    {
        var dashboards = AllDashboardsSteps.GetDashboards();

        Assert.That(
            dashboards.Count(x => x.Name == dashboardName && x.Description == dashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is NOT expected to have dashboard with name = '{dashboardName}' and description = '{dashboardDescription}'!");
    }
}