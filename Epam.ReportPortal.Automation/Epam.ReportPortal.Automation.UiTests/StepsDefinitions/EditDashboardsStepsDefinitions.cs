namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions;

[Binding]
public sealed class EditDashboardsStepsDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public EditDashboardsStepsDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"\[context]")]
    public void GivenContext()
    {
        _scenarioContext.Pending();
    }

    [When(@"\[action]")]
    public void WhenAction()
    {
        _scenarioContext.Pending();
    }

    [Then(@"\[outcome]")]
    public void ThenOutcome()
    {
        _scenarioContext.Pending();
    }
}