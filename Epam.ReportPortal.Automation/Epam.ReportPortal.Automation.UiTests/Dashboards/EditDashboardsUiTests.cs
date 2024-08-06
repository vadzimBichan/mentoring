using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class EditDashboardsUiTestsBase : ReportPortalUiTestsBaseWithInstancePerTest
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();

    private string _dashboardName;
    private string _dashboardDescription;
    private string _newDashboardName;
    private string _newDashboardDescription;

    [SetUp]
    public void GenerateData()
    {
        _dashboardName = $"DN_{StringUtils.GenerateRandomString(10)}";
        _dashboardDescription = $"DD_{StringUtils.GenerateRandomString(20)}";
        _newDashboardName = $"DN_new_{StringUtils.GenerateRandomString(10)}";
        _newDashboardDescription = $"DD_new_{StringUtils.GenerateRandomString(20)}";
    }

    [Test]
    public void ItIsPossibleToUpdateDashboardFromTable()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.UpdateDashboardInTable(_dashboardName, _newDashboardName, _newDashboardDescription);
        Assert.That(AllDashboardsSteps.IsEditDashboardDialogOpened(), Is.False);

        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is NOT expected to have dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
        Assert.That(
            dashboards.Count(x => x.Name == _newDashboardName && x.Description == _newDashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected to have ONE dashboard with name = '{_newDashboardName}' and description = '{_newDashboardDescription}'!");
    }

    [Test]
    [Description("Check that it is needed to confirm removing")]
    public void ItIsPossibleToCancelDashboardUpdateFromTable()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.TryUpdateDashboardInTable(_dashboardName, _newDashboardName, _newDashboardDescription);
        Assert.That(AllDashboardsSteps.IsEditDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseDeleteDashboardDialog();
        var dashboards = AllDashboardsSteps.GetDashboards();
        Assert.That(
            dashboards.Count(x => x.Name == _dashboardName && x.Description == _dashboardDescription),
            Is.EqualTo(1),
            $"Dashboards table is expected to have ONE dashboard with name = '{_dashboardName}' and description = '{_dashboardDescription}'!");
        Assert.That(
            dashboards.Count(x => x.Name == _newDashboardName && x.Description == _newDashboardDescription),
            Is.EqualTo(0),
            $"Dashboards table is NOT expected to have dashboard with name = '{_newDashboardName}' and description = '{_newDashboardDescription}'!");
    }
}