namespace Epam.ReportPortal.Automation.UiTests.Base
{
    [TestFixture]
    public abstract class ReportPortalUiTestsWithOneInstancePerSuiteBase
    {
        protected WebSteps WebSteps;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            WebSteps = new WebSteps();
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            // WebSteps.BrowserSteps.CloseBrowser();
        }
    }
}
