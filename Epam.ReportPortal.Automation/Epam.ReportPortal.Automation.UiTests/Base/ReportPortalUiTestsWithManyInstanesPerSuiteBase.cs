using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
public abstract class ReportPortalUiTestsWithManyInstancesPerSuiteBase
{
    protected Browser Browser;
    protected TestConfiguration TestConfiguration;
    protected LoginPageSteps LoginPageSteps => new(TestContext.CurrentContext.Test.Name);

    [SetUp]
    public void BeforeEach()
    {
        TestConfiguration = TestConfiguration.GetConfiguration();
        LogConfiguration.Setup();
        Browser = Browser.GetInstance(TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public void AfterEach()
    {
        Browser.Close(TestContext.CurrentContext.Test.Name);
    }
}