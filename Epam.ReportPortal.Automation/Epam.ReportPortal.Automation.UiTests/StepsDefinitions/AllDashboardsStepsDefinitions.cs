using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

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

    [Given(@"New dashboard is created and opened")]
    public void GivenNewDashboardIsCreatedAndOpened()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var dashboardDescription = StringUtils.GenerateRandomString(20);
        AllDashboardsSteps.CreateDashboard(dashboardName, dashboardDescription);
        _scenarioContext[nameof(TestData.FirstDashboardName)] = dashboardName;
        _scenarioContext[nameof(TestData.FirstDashboardDescription)] = dashboardDescription;
    }

    [Given(@"Second dashboard is created and opened")]
    public void GivenSecondDashboardIsCreatedAndOpened()
    {
        var dashboardName = StringUtils.GenerateRandomString(10);
        var dashboardDescription = StringUtils.GenerateRandomString(20);
        AllDashboardsSteps.CreateDashboard(dashboardName, dashboardDescription);
        _scenarioContext[nameof(TestData.SecondDashboardName)] = _scenarioContext[nameof(TestData.FirstDashboardName)];
        _scenarioContext[nameof(TestData.SecondDashboardDescription)] = _scenarioContext[nameof(TestData.FirstDashboardDescription)];
        _scenarioContext[nameof(TestData.FirstDashboardName)] = dashboardName;
        _scenarioContext[nameof(TestData.FirstDashboardDescription)] = dashboardDescription;
    }


    [When(@"User navigates to All Dashboards Page")]
    public void WhenUserNavigatesToAllDashboardsPage()
    {
        AllDashboardsSteps.OpenAllDashboardsPage();
    }

    [Then(@"Dashboard name is updated on All Dashboards Page")]
    [Then(@"Dashboard description is updated on All Dashboards Page")]
    public void ThenDashboardOrDescriptionNameIsUpdatedOnAllDashboardsPage()
    {
        var dashboards = AllDashboardsSteps.GetDashboards();

        var initialDashboardName = _scenarioContext[nameof(TestData.FirstDashboardName)].ToString();
        var initialDashboardDescription = _scenarioContext[nameof(TestData.FirstDashboardDescription)].ToString();
        Assert.That(
            dashboards.Count(x => x.Name == initialDashboardName && x.Description == initialDashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is expected NOT having dashboard with name='{initialDashboardName}' and description='{initialDashboardDescription}', but it DOES have");

        var updatedDashboardName = _scenarioContext[nameof(TestData.UpdatedDashboardName)].ToString();
        var updatedDashboardDescription = _scenarioContext[nameof(TestData.UpdatedDashboardDescription)].ToString();
        Assert.That(
            dashboards.Count(x => x.Name == updatedDashboardName && x.Description == updatedDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected to have dashboard with name='{updatedDashboardName}' and description='{updatedDashboardDescription}', but it does NOT have");
    }

    [Then(@"Dashboard name is NOT updated on All Dashboards Page")]
    [Then(@"Dashboard description is NOT updated on All Dashboards Page")]
    public void ThenDashboardNameOrDescriptionIsNotUpdatedOnAllDashboardsPage()
    {
        var dashboard = AllDashboardsSteps.GetDashboards();

        var initialDashboardName = _scenarioContext[nameof(TestData.FirstDashboardName)].ToString();
        var initialDashboardDescription = _scenarioContext[nameof(TestData.FirstDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == initialDashboardName && x.Description == initialDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected still to have old dashboard with name='{initialDashboardName}' and description='{initialDashboardDescription}', but it does NOT have");

        var updatedDashboardName = _scenarioContext[nameof(TestData.UpdatedDashboardName)].ToString();
        var updatedDashboardDescription = _scenarioContext[nameof(TestData.UpdatedDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == updatedDashboardName && x.Description == updatedDashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is expected NOT having dashboard with name='{updatedDashboardName}' and description='{updatedDashboardDescription}', but it DOES have");
    }

    [Then(@"Two original dashboards are displayed on All Dashboards Page")]
    public void ThenTwoOriginalDashboardsAreDisplayedOnAllDashboardsPage()
    {
        var dashboard = AllDashboardsSteps.GetDashboards();

        var firstDashboardName = _scenarioContext[nameof(TestData.FirstDashboardName)].ToString();
        var firstDashboardDescription = _scenarioContext[nameof(TestData.FirstDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == firstDashboardName && x.Description == firstDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected still to have dashboard 1 with name='{firstDashboardName}' and description='{firstDashboardDescription}', but it does NOT have");

        var secondDashboardName = _scenarioContext[nameof(TestData.SecondDashboardName)].ToString();
        var secondDashboardDescription = _scenarioContext[nameof(TestData.SecondDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == secondDashboardName && x.Description == secondDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected still to have dashboard 2 with name='{secondDashboardName}' and description='{secondDashboardDescription}', but it does NOT have");
    }
}