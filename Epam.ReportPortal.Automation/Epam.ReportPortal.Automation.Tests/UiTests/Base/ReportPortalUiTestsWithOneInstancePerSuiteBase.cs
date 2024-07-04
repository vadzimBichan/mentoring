using NUnit.Framework;

namespace Epam.ReportPortal.Automation.Tests.UiTests.Base
{
    [TestFixture]
    public abstract class ReportPortalUiTestsWithOneInstancePerSuiteBase
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            // TODO
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            // TODO
        }
    }
}
