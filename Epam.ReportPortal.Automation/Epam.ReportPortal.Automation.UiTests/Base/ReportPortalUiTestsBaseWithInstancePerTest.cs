using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
public abstract class ReportPortalUiTestsBaseWithInstanePerTest
{
    protected LoginPageSteps LoginPageSteps => new(TestContext.CurrentContext.Test.Name);

    [SetUp]
    public void BeforeEach()
    {
        Browser.GetInstance(TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public void AfterEach()
    {
        Browser.Close(TestContext.CurrentContext.Test.Name);
    }
}