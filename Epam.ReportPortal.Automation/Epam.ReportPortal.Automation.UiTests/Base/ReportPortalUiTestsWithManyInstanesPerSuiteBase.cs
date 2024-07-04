namespace Epam.ReportPortal.Automation.UiTests.Base
{
    [TestFixture]
    public abstract class ReportPortalUiTestsWithManyInstancesPerSuiteBase
    {
        protected WebSteps WebSteps;

        [OneTimeSetUp]
        public void BeforeEach()
        {
            WebSteps = new WebSteps();
        }

        [OneTimeTearDown]
        public void AfterEach()
        {
            // WebSteps.BrowserSteps.CloseBrowser();
        }
    }
}
