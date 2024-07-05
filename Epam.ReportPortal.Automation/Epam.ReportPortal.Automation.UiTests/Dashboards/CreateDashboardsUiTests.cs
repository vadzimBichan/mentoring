using Epam.ReportPortal.Automation.Core.Utils;
using Epam.ReportPortal.Automation.UiTests.Base;

namespace Epam.ReportPortal.Automation.UiTests.Dashboards
{
    [TestFixture]
    public class CreateDashboardsUiTests : ReportPortalUiTestsWithManyInstancesPerSuiteBase
    {
        [Test]
        public void ItIsPossibleToCreateDashboardWithUniqueName()
        {
            WebSteps.LoginPageSteps.OpenLoginPage();
            WebSteps.LoginPageSteps.LoginWithCredentials(WebSteps.TestConfiguration.Login, WebSteps.TestConfiguration.Password);

            WebSteps.AllDashboardsSteps.ValidatePageTitle("bla bla");
            var initialDashboardsCount = WebSteps.AllDashboardsSteps.GetDashboardsCount();
            var dashboardName = StringUtils.GenerateRandomString(10);
            WebSteps.AllDashboardsSteps.CreateDashboard(dashboardName, "Test Description");

            WebSteps.ParticularDashboardSteps.ValidatePageTitle("bla bla");

            WebSteps.AllDashboardsSteps.OpenAllDashboardsPage();
            Assert.That(WebSteps.AllDashboardsSteps.GetDashboardsCount(), Is.EqualTo(initialDashboardsCount + 1));
        }

        [Test]
        public void ItIsImpossibleToCreateDashboardWithDuplicatedName()
        {
            Assert.Fail("Not implemented!");
        }

        [Test]
        public void ItIsImpossibleToCreateDashboardWithEmptyName()
        {
            Assert.Fail("Not implemented!");
        }
    }
}
