using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
public class CreateDashboardsUiTests : ReportPortalUiTestsWithManyInstancesPerSuiteBase
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();
    public ParticularDashboardPageSteps ParticularDashboardSteps => new();

    [Test]
    [TestCaseSource(nameof(AllowedLengthData))]
    public void ItIsPossibleToCreateDashboardWithUniqueName(int dashboardNameLength)
    {
        LoginPageSteps.OpenLoginPage();
        LoginPageSteps.LoginWithCredentials(TestConfiguration.Login, TestConfiguration.Password);

        AllDashboardsSteps.ValidatePageTitle("Report Portal");
        var initialDashboardsCount = AllDashboardsSteps.GetDashboardsCount();
        var dashboardName = StringUtils.GenerateRandomString(dashboardNameLength);
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
    public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols([Values("", "A", "AB")] string dashboardName)
    {
        Assert.Fail($"Not implemented for '{dashboardName}'!");
    }

    public static IEnumerable<int> AllowedLengthData()
    {
        yield return 3; // min length
        yield return 128; // max length
    }
}