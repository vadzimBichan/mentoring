using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Models;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class CreateDashboardsUiTestsBase : ReportPortalUiTestsBaseWithInstancePerTest
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();
    public ParticularDashboardPageSteps ParticularDashboardSteps => new();

    [Test]
    [TestCaseSource(nameof(AllowedLengthData))]
    public void ItIsPossibleToCreateDashboardWithUniqueName(int dashboardNameLength)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var dashboardName = StringUtils.GenerateRandomString(dashboardNameLength);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.False);
        Assert.That(ParticularDashboardSteps.GetWidgetsCount(), Is.EqualTo(0));

        AllDashboardsSteps.OpenAllDashboardsPage();
        CheckDashboardExistsInTheTable(AllDashboardsSteps.GetDashboards(), dashboardName, "Test Description)");
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var dashboardName = StringUtils.GenerateRandomString(10);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");

        AllDashboardsSteps.OpenAllDashboardsPage();
        var dashboardsBefore = AllDashboardsSteps.GetDashboards();
        Assert.That(GetDashboardsInTheTable(dashboardsBefore, dashboardName, "Test Description)").Count, Is.EqualTo(1));

        AllDashboardsSteps.TryCreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseAddNewDashboardDialog();
        var dashboardsAfter = AllDashboardsSteps.GetDashboards();
        Assert.That(GetDashboardsInTheTable(dashboardsAfter, dashboardName, "Test Description)").Count, Is.EqualTo(1));
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(
        [Values("", "A", "AB")] string dashboardName)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        AllDashboardsSteps.TryCreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseAddNewDashboardDialog();
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.False);
        var dashboardsAfter = AllDashboardsSteps.GetDashboards();
        Assert.That(GetDashboardsInTheTable(dashboardsAfter, dashboardName, "Test Description)").Count, Is.EqualTo(0));
    }

    public static IEnumerable<int> AllowedLengthData()
    {
        yield return 3; // min length
        yield return 128; // max length
    }
}