using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions;

[Binding]
public sealed class LoginStepsDefinitions
{
    public LoginPageSteps LoginPageSteps => new();

    private readonly ScenarioContext _scenarioContext;

    public LoginStepsDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"Test User is logged in")]
    public void GivenTestUserIsLoggedIn()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();
    }
}