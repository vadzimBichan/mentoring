using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
public class CreateDashboardsUiTests : ReportPortalUiTestsWithManyInstancesPerSuiteBase
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();
    public ParticularDashboardPageSteps ParticularDashboardSteps => new();

    [Test]
    public void ItIsPossibleToCreateDashboardWithUniqueName()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithCredentials(TestConfiguration.Login, TestConfiguration.Password);

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(10);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");

        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithEmptyName()
    {
        Assert.Fail("Not implemented!");
    }
}