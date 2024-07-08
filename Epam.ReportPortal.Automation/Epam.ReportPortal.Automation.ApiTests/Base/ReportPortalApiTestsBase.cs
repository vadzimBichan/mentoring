using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Epam.ReportPortal.Automation.Core.Utils;

namespace Epam.ReportPortal.Automation.ApiTests.Base;

[TestClass]
public abstract class ReportPortalApiTestsBase
{
    private ExtentReports _extent;
    private ExtentTest _test;

    [ClassInitialize]
    public void BeforeAll()
    {
        _extent = new ExtentReports();
        var fileName = $"Report_{DateTimeUtils.GetDateTimeString()}.html";
        var htmlReporter = new ExtentSparkReporter(Path.Combine(TestContext.CurrentContext.TestDirectory, fileName));
        _extent.AttachReporter(htmlReporter);
    }

    [TestInitialize]
    public void BeforeEach()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        _test = _extent.CreateTest(testName);
    }

    [TestCleanup]
    public void AfterEach()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        switch (status)
        {
            case TestStatus.Failed:
                _test.Fail($"Test failed \n{TestContext.CurrentContext.Result.Message}");
                break;
            case TestStatus.Skipped:
                _test.Skip("Test skipped");
                break;
            case TestStatus.Passed:
                _test.Pass("Test passed");
                break;
            default:
                _test.Info("Test outcome: " + status);
                break;
        }
    }

    [ClassCleanup]
    public void AfterAll()
    {
        _extent.Flush();
    }
}