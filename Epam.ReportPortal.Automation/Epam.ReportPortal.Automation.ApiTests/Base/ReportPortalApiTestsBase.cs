using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Epam.ReportPortal.Automation.Core.Utils;
using Xunit.Abstractions;

namespace Epam.ReportPortal.Automation.ApiTests.Base
{
    public class ReportPortalApiTestsBase : IDisposable
    {
        public ExtentReports extent;
        public ExtentTest test;
        private readonly string _testName;

        private bool isPassed { get; set; } 

        public ReportPortalApiTestsBase(ITestOutputHelper output)
        {
            var type = output.GetType();
            var testMember = type.GetField("test", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);
            _testName = test.DisplayName;

            extent = new ExtentReports();

            var fileName = $"Report_{DateTimeUtils.GetDateTimeString()}.html";
            var location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var htmlReporter = new ExtentSparkReporter(Path.Combine(location, fileName));
            extent.AttachReporter(htmlReporter);

            this.test = extent.CreateTest(_testName);
        }

        public void RunTest(Action testBody)
        {
            try
            {
                testBody.Invoke();
                isPassed = true;
            }
            catch
            {
                isPassed = false;
                throw;  
            }
        }

        public void Dispose()
        {
            if (isPassed)
                test.Log(Status.Pass, "Test Passed");
            else
                test.Log(Status.Fail, "Test Failed");

            extent.Flush();
        }
    }
}