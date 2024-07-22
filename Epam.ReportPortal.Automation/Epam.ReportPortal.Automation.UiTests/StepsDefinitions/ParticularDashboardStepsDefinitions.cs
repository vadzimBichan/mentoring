using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions;

[Binding]
public sealed class ParticularDashboardStepsDefinitions
{
    public ParticularDashboardPageSteps ParticularDashboardPageSteps => new();

    private readonly ScenarioContext _scenarioContext;

    public ParticularDashboardStepsDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"User edits dashboard name to '([^']*)' and clicks save changes")]
    public void GivenUserEditsDashboardNameToAndClicksSaveChanges(string dashboardName)
    {
        ParticularDashboardPageSteps.EditDashboardNameAndDescription(dashboardName, null);
    }

    [Given(@"User edits dashboard description to '([^']*)' and clicks save changes")]
    public void GivenUserEditsDashboardDescriptionToAndClicksSaveChanges(string dashboardDescription)
    {
        ParticularDashboardPageSteps.EditDashboardNameAndDescription(null, dashboardDescription);
    }

    [When(@"User closes Edit Dashboard dialog on the Dashboard Page")]
    public void WhenUserClosesEditDashboardDialogOnTheDashboardPage()
    {
        ParticularDashboardPageSteps.CloseEditDashboardDialog();
    }

    [Then(@"Dashboard name is displayed as '([^']*)' on the Dashboard Page")]
    [Then(@"Dashboard name is still displayed as '([^']*)' on the Dashboard Page")]
    public void ThenDashboardNameIsDisplayedAsOnTheDashboardPage(string dashboardName)
    {
        ParticularDashboardPageSteps.CheckDashboardNameInBreadcrumbs(dashboardName.ToUpper());
    }

    [Then(@"Edit dialog is closed on the Dashboard Page")]
    public void ThenEditDialogIsClosedOnTheDashboardPage()
    {
        Assert.That(ParticularDashboardPageSteps.IsEditDashboardDialogOpened(), Is.False,
            "Edit dialog should be closed, but it is displayed");
    }

    [Then(@"Edit dialog is NOT closed on the Dashboard Page")]
    public void ThenEditDialogIsNotClosedOnTheDashboardPage()
    {
        Assert.That(ParticularDashboardPageSteps.IsEditDashboardDialogOpened(), Is.True,
            "Edit dialog should be displayed, but it is closed");
    }
}