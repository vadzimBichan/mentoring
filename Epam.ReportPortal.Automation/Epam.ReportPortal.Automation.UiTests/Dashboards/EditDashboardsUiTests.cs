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

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        CheckDashboardExistsInTheTable(AllDashboardsSteps.GetDashboards(), _dashboardName, _dashboardDescription);

        AllDashboardsSteps.UpdateDashboardInTable(_dashboardName, _newDashboardName, _newDashboardDescription);
        Assert.That(AllDashboardsSteps.IsEditDashboardDialogOpened(), Is.False);

        var dashboards = AllDashboardsSteps.GetDashboards();
        CheckDashboardDoesNotExistInTheTable(dashboards, _dashboardName, _dashboardDescription);
        CheckDashboardExistsInTheTable(dashboards, _newDashboardName, _newDashboardDescription);
    }

    [Test]
    [Description("Check that it is needed to confirm removing")]
    public void ItIsPossibleToCancelDashboardUpdateFromTable()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.CreateDashboard(_dashboardName, _dashboardDescription);
        AllDashboardsSteps.OpenAllDashboardsPage();
        CheckDashboardExistsInTheTable(AllDashboardsSteps.GetDashboards(), _dashboardName, _dashboardDescription);

        AllDashboardsSteps.TryUpdateDashboardInTable(_dashboardName, _newDashboardName, _newDashboardDescription);
        Assert.That(AllDashboardsSteps.IsEditDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseDeleteDashboardDialog();
        var dashboards = AllDashboardsSteps.GetDashboards();
        CheckDashboardDoesNotExistInTheTable(dashboards, _newDashboardName, _newDashboardDescription);
        CheckDashboardExistsInTheTable(dashboards, _dashboardName, _dashboardDescription);
    }
}