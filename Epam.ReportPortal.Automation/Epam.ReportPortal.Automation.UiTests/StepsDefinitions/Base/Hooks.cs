using Epam.ReportPortal.Automation.CoreSelenium.Base;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

[Binding]
// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
public sealed class Hooks
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        Browser.GetInstance();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Browser.Close();
    }
}