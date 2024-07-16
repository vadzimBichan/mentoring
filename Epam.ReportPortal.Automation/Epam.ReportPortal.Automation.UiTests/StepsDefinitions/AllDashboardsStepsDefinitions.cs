using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System.Collections.Generic;
using System.Xml.Linq;

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
        _scenarioContext[nameof(TestData.UsedDashboardName)] = dashboardName;
        _scenarioContext[nameof(TestData.UsedDashboardDescription)] = dashboardDescription;
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

        var usedDashboardName = _scenarioContext[nameof(TestData.UsedDashboardName)].ToString();
        var usedDashboardDescription = _scenarioContext[nameof(TestData.UsedDashboardDescription)].ToString();
        Assert.That(
            dashboards.Count(x => x.Name == usedDashboardName && x.Description == usedDashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is expected NOT having dashboard with name='{usedDashboardName}' and description='{usedDashboardDescription}', but it DOES have");

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

        var usedDashboardName = _scenarioContext[nameof(TestData.UsedDashboardName)].ToString();
        var usedDashboardDescription = _scenarioContext[nameof(TestData.UsedDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == usedDashboardName && x.Description == usedDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected still to have old dashboard with name='{usedDashboardName}' and description='{usedDashboardDescription}', but it does NOT have");

        var updatedDashboardName = _scenarioContext[nameof(TestData.UpdatedDashboardName)].ToString();
        var updatedDashboardDescription = _scenarioContext[nameof(TestData.UpdatedDashboardDescription)].ToString();
        Assert.That(
            dashboard.Count(x => x.Name == updatedDashboardName && x.Description == updatedDashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is expected NOT having dashboard with name='{updatedDashboardName}' and description='{updatedDashboardDescription}', but it DOES have");
    }
}