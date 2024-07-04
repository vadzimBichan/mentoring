using Epam.ReportPortal.Automation.Core.Selenium;
using Epam.ReportPortal.Automation.Core.Selenium.Factory;

namespace Epam.ReportPortal.Automation.Tests.UiTests.Base
{
    [TestFixture]
    public abstract class ReportPortalUiTestsWithManyInstancesPerSuiteBase
    {
        private Browser? _browser;
        protected WebSteps? WebSteps;

        [OneTimeSetUp]
        public void BeforeEach()
        {
            _browser = new Browser(new ChromeDriverFactory());
            _browser.Maximize();

            WebSteps = new WebSteps(_browser);
        }

        [OneTimeTearDown]
        public void AfterEach()
        {
            _browser?.Quit();
        }
    }
}
