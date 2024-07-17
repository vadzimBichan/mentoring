using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

[Binding]
// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
public sealed class Hooks
{
    [BeforeTestRun]
    public void BeforeTestsRun()
    {
        ConfigurationManager.GetConfiguration();
        LogConfiguration.Setup();
    }

    [AfterTestRun]
    public void AfterTestsRun()
    {
        // not used at the moment
    }

    [BeforeScenario]
    public void BeforeEachScenario()
    {
        Browser.GetInstance();
    }

    [AfterScenario]
    public void AfterEachScenario()
    {
        Browser.Close();
    }
}