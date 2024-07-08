using Epam.ReportPortal.Automation.ApiTests.Base;
using Xunit.Abstractions;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards
{
    public class DashboardApiTests : ReportPortalApiTestsBase
    {
        public DashboardApiTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void ItIsImpossibleToCreateDashboardWithEmptyName()
        {
            RunTest(() =>
            {
                Assert.Fail("Not implemented!");
            });
        }

        [Fact]
        public void ItIsImpossibleToCreateDashboardWithNameHavingOneSymbol()
        {
            RunTest(() =>
            {
                Assert.Fail("Not implemented!");
            });
        }

        [Fact]
        public void ItIsImpossibleToCreateDashboardWithNameHavingTwoSymbols()
        {
            RunTest(() =>
            {
                Assert.Fail("Not implemented!");
            });
        }
    }
}
