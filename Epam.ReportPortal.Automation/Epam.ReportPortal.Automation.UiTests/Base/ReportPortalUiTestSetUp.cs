using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[SetUpFixture] // https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
public class ReportPortalUiTestSetUp
{
    [OneTimeSetUp]
    public void BeforeAllTests()
    {
        ConfigurationManager.GetConfiguration();
        LogConfiguration.Setup();
    }

    [OneTimeTearDown]
    public void AfterAllTests()
    {
        // not used at the moment
    }
}