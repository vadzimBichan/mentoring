using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Models;
using System.Net;
using System.Net.Mail;

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
        CreatedResources.GetResources();
    }

    [TearDown]
    public void AfterEach()
    {
        Browser.Close();

        try
        {
            var dashboardsApiSteps = new DashboardApiSteps();
            foreach (var dashboardId in CreatedResources.GetResources().Dashboards)
            {
                var response = dashboardsApiSteps.DeleteDashboardRequest(dashboardId);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Dashboard with id = '{dashboardId}' was not deleted! Response status code = '{response.StatusCode}'");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            CreatedResources.CleanDashboards();
        }
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