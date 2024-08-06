using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class RemoveDashboardsUiTestsBase : ReportPortalUiTestsBaseWithInstancePerTest
{
    public AllDashboardsPageSteps AllDashboardsSteps => new();
    public ParticularDashboardPageSteps ParticularDashboardSteps => new();

    [Test]
    public void ItIsPossibleToRemoveDashboardFromTable()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsPossibleToCancelDashboardRemovingInTable()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsPossibleToRemoveDashboardFromDashboardPage()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsPossibleToCancelDashboardRemovingOnDashboardPage()
    {
        Assert.Fail("Not implemented!");
    }
}