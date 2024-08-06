using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Models;

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

    public void CheckDashboardExistsInTheTable(List<Dashboard> dashboards, string dashboardName, string dashboardDescription)
    {
        Assert.That(
            dashboards.Count(x => x.Name == dashboardName && x.Description == dashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table should have dashboard with name = '{dashboardName}' and description = '{dashboardDescription}'!");
    }

    public void CheckDashboardDoesNotExistInTheTable(List<Dashboard> dashboards, string dashboardName, string dashboardDescription)
    {
        Assert.That(
            dashboards.Count(x => x.Name == dashboardName && x.Description == dashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table should NOT have dashboard with name = '{dashboardName}' and description = '{dashboardDescription}'!");
    }

    public List<Dashboard> GetDashboardsInTheTable(List<Dashboard> dashboards, string dashboardName, string dashboardDescription)
    {
        return dashboards.Where(x => x.Name == dashboardName && x.Description == dashboardDescription).ToList();
    }
}