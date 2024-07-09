using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Epam.ReportPortal.Automation.Core.Utils;
using NUnit.Framework.Interfaces;

namespace Epam.ReportPortal.Automation.ApiTests.Base;

[TestFixture]
public class ReportPortalApiTestsBase
{
    private ExtentReports _extent;
    private ExtentTest _test;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _extent = new ExtentReports();
        var fileName = $"Report_{DateTimeUtils.GetDateTimeString()}.html";
        var htmlReporter = new ExtentSparkReporter(Path.Combine(TestContext.CurrentContext.TestDirectory, fileName));
        _extent.AttachReporter(htmlReporter);
    }

    [SetUp]
    public void SetUp()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        _test = _extent.CreateTest(testName);
    }

    [TearDown]
    public void TearDown()
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

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _extent.Flush();
    }
}