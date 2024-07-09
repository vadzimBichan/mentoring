using Epam.ReportPortal.Automation.ApiTests.Base;
using Epam.ReportPortal.Automation.Core.Utils;
using Xunit.Abstractions;

namespace Epam.ReportPortal.Automation.ApiTests.Dashboards
{
    public class DashboardApiTests : ReportPortalApiTestsBase
    {
        public DashboardApiTests(ITestOutputHelper output) : base(output) { }

        [Theory, MemberData(nameof(AllowedLengthData))]
        public void ItIsPossibleToCreateDashboardWithUniqueName(string dashboardName)
        {
            RunTest(() =>
            {
                Assert.Fail($"Not implemented for '{dashboardName}'!");
            });
        }

        [Fact]
        public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
        {
            RunTest(() =>
            {
                Assert.Fail("Not implemented!");
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("AB")]
        public void ItIsImpossibleToCreateDashboardWithNameHavingLessThanThreeSymbols(string dashboardName)
        {
            RunTest(() =>
            {
                Assert.Fail($"Not implemented for '{dashboardName}'!");
            });
        }

        public static IEnumerable<object[]> AllowedLengthData => new List<object[]>
        {
            new object[] {StringUtils.GenerateRandomString(3) },
            new object[] {StringUtils.GenerateRandomString(128) }
        };
    }
}
