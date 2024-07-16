using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

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

    [Given(@"User edits dashboard name to new unique value and clicks save changes")]
    public void GivenUserEditsDashboardNameToNewUniqueValueAndClicksSaveChanges()
    {
        var newDashboardName = StringUtils.GenerateRandomString(10);
        ParticularDashboardPageSteps.EditDashboardNameAndDescription(newDashboardName, null);
        _scenarioContext[nameof(TestData.UpdatedDashboardName)] = newDashboardName;
        _scenarioContext[nameof(TestData.UpdatedDashboardDescription)] = _scenarioContext[nameof(TestData.UsedDashboardDescription)];
    }

    [Given(@"User edits dashboard description to new unique value and clicks save changes")]
    public void GivenUserEditsDashboardDescriptionToNewUniqueValueAndClicksSaveChanges()
    {
        var newDashboardDescription = StringUtils.GenerateRandomString(20);
        ParticularDashboardPageSteps.EditDashboardNameAndDescription(null, newDashboardDescription);
        _scenarioContext[nameof(TestData.UpdatedDashboardName)] = _scenarioContext[nameof(TestData.UsedDashboardName)];
        _scenarioContext[nameof(TestData.UpdatedDashboardDescription)] = newDashboardDescription;
    }

    [Given(@"User edits dashboard name to invalid ""([^""]*)"" and clicks save changes")]
    public void GivenUserEditsDashboardNameToInvalidAndClicksSaveChanges(string newDashboardName)
    {
        ParticularDashboardPageSteps.EditDashboardNameAndDescription(newDashboardName, null);
        _scenarioContext[nameof(TestData.UpdatedDashboardName)] = newDashboardName;
        _scenarioContext[nameof(TestData.UpdatedDashboardDescription)] = _scenarioContext[nameof(TestData.UsedDashboardDescription)];
    }

    [When(@"User closes Edit Dashboard dialog on the Dashboard Page")]
    public void WhenUserClosesEditDashboardDialogOnTheDashboardPage()
    {
        ParticularDashboardPageSteps.CloseEditDashboardDialog();
    }

    [Then(@"Dashboard name is updated on the Dashboard Page")]
    public void ThenDashboardNameIsUpdatedOnTheDashboardPage()
    {
        ParticularDashboardPageSteps.CheckDashboardNameInBreadcrumbs(_scenarioContext[nameof(TestData.UpdatedDashboardName)].ToString());
    }

    [Then(@"Dashboard name is NOT updated on the Dashboard Page")]
    public void ThenDashboardNameIsNotUpdatedOnTheDashboardPage()
    {
        ParticularDashboardPageSteps.CheckDashboardNameInBreadcrumbs(_scenarioContext[nameof(TestData.UsedDashboardName)].ToString());
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