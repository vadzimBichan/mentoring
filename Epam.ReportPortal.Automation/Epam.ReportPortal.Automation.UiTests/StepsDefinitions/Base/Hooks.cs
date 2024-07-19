using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

[Binding]
// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
public sealed class Hooks
{
    [BeforeTestRun]
    public static void BeforeTestsRun()
    {
        ConfigurationManager.GetConfiguration();
        LogConfiguration.Setup();
    }

    [AfterTestRun]
    public static void AfterTestsRun()
    {
        // not used at the moment
    }

    [BeforeFeature]
    public void BeforeEachFeature()
    {
        // TODO: Add project creation via admin to have own project per feature file
        // And put its id in feature context to use later (for example to clean)
        // Use API steps for more robust solution
    }

    [AfterFeature]
    public void AfterEachFeature()
    {
        // TODO: Clean projects via admin
        // Use API steps for more robust solution
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