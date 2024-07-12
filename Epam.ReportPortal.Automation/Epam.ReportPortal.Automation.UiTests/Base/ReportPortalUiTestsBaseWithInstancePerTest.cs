using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)] // https://docs.nunit.org/articles/nunit/writing-tests/attributes/fixturelifecycle.html
public abstract class ReportPortalUiTestsBaseWithInstancePerTest
{
    protected LoginPageSteps LoginPageSteps => new();

    [SetUp]
    public void BeforeEach()
    {
        Browser.GetInstance();
    }

    [TearDown]
    public void AfterEach()
    {
        Browser.Close();
    }
}