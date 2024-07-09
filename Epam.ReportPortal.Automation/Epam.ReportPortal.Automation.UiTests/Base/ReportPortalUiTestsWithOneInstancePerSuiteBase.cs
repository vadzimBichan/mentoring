using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
public abstract class ReportPortalUiTestsWithOneInstancePerSuiteBase
{
    protected Browser Browser;
    protected TestConfiguration TestConfiguration;
    protected LoginPageSteps LoginPageSteps => new(TestContext.CurrentContext.Test.ClassName);

    [OneTimeSetUp]
    public void BeforeAll()
    {
        TestConfiguration = TestConfiguration.GetConfiguration();
        LogConfiguration.Setup();
        Browser = Browser.GetInstance(TestContext.CurrentContext.Test.ClassName);
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        Browser.Close(TestContext.CurrentContext.Test.ClassName);
    }
}