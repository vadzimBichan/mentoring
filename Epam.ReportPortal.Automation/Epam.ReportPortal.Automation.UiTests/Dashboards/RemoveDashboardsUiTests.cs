using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class RemoveDashboardsUiTestsBase : ReportPortalUiTestsBaseWithInstancePerTest
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();
    public ParticularDashboardPageSteps ParticularDashboardSteps => new();

    private string _dashboardName;
    private string _dashboardDescription;

    [SetUp]
    public void GenerateData()
    {
        _dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        _dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
    }

    [Test]
    public void ItIsPossibleToRemoveDashboardInTable()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.DeleteDashboardInTable(_dashboardName);

        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(dashboards.Count, Is.EqualTo(initialDashboardsCount));
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is NOT expected to have dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
    }

    [Test]
    [Description("Check that it is needed to confirm removing")]
    public void ItIsPossibleToCancelDashboardRemovingInTable()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        AllDashboardsSteps.TryDeleteDashboardInTable(_dashboardName);
        Assert.That(AllDashboardsSteps.IsDeleteDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseDeleteDashboardDialog();

        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected to have ONE dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
    }

    [Test]
    public void ItIsPossibleToRemoveDashboardOnDashboardPage()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.OpenParticularDashboardPage(_dashboardName);
        ParticularDashboardSteps.DeleteDashboard();

        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(dashboards.Count, Is.EqualTo(initialDashboardsCount));
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is NOT expected to have dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
    }

    [Test]
    [Description("Check that it is needed to confirm removing")]
    public void ItIsPossibleToCancelDashboardRemovingOnDashboardPage()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        ParticularDashboardSteps.TryDeleteDashboard();
        Assert.That(ParticularDashboardSteps.IsDeleteDashboardDialogOpened(), Is.True);

        ParticularDashboardSteps.CloseDeleteDashboardDialog();
        AllDashboardsSteps.OpenAllDashboardsPage();

        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected to have ONE dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
    }
}