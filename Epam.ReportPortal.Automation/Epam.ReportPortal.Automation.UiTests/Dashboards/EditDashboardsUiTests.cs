using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class EditDashboardsUiTestsBase : ReportPortalUiTestsBaseWithInstanePerTest
{
    [Test]
    public void ItIsPossibleToChangeDashboardName()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsPossibleToChangeDashboardDescription()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsNotPossibleToChangeDashboardNameToExistingOne()
    {
        Assert.Fail("Not implemented!");
    }

    [Test]
    public void ItIsNotPossibleToChangeDashboardNameToHaveLengthLessThanTreeSymbols()
    {
        Assert.Fail("Not implemented!");
    }
}