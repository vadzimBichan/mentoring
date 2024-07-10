using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class CreateDashboardsUiTests : ReportPortalUiTestsWithManyInstancesPerSuiteBase
{
    public AllDashboardsPageSteps AllDashboardsSteps => new(TestContext.CurrentContext.Test.Name);
    public ParticularDashboardPageSteps ParticularDashboardSteps => new(TestContext.CurrentContext.Test.Name);

    [Test]
    [TestCaseSource(nameof(AllowedLengthData))]
    public void ItIsPossibleToCreateDashboardWithUniqueName(int dashboardNameLength)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithCredentials(TestConfiguration.TestUserLogin, TestConfiguration.TestUserPassword);

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
        LoginPageSteps.LoginWithCredentials(TestConfiguration.TestUserLogin, TestConfiguration.TestUserPassword);

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(10);
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");

        AllDashboardsSteps.OpenAllDashboardsPage();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));

        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");
        Assert.That(AllDashboardsSteps.IsAddNewDashboardDialogOpened(), Is.True);

        AllDashboardsSteps.CloseAddNewDashboardDialog();
        Assert.That(AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));
    }

    [Test]
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(
        [Values("", "A", "AB")] string dashboardName)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithCredentials(TestConfiguration.TestUserLogin, TestConfiguration.TestUserPassword);

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");
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