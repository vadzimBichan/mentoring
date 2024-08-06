using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
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
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(dashboardNameLength);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.False);

        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(10);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");

        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.TryCreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseAddNewDashboardDialog();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(
        [Values("", "A", "AB")] string dashboardName)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithTestUser();

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        AllDashboardsSteps.TryCreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseAddNewDashboardDialog();
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.False);
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount));
    }

    public static IEnumerable<int> AllowedLengthData()
    {
        yield return 3; // min length
        yield return 128; // max length
    }
}