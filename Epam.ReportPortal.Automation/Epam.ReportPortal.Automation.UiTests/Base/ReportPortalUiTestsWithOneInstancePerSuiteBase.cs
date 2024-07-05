using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
public abstract class ReportPortalUiTestsWithOneInstancePerSuiteBase
{
    protected Browser Browser;
    protected TestConfiguration TestConfiguration;
    protected LoginPageSteps LoginPageSteps => new();

    [OneTimeSetUp]
    public void BeforeAll()
    {
        TestConfiguration = TestConfiguration.GetConfiguration();
        Browser = Browser.GetInstance;
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        Browser.Close();
    }
}