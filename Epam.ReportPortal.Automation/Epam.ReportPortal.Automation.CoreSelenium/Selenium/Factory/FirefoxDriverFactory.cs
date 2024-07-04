using System.Text;

namespace Epam.ReportPortal.Automation.CoreSelenium.Selenium.Factory
{
    public class FirefoxDriverFactory : IWebDriverFactory
    {
        public IWebDriver? Create()
        {
            var service = FirefoxDriverService.CreateDefaultService("TODO");
            var options = new FirefoxOptions {Profile = CreateDefaultFirefoxProfile(), LogLevel = FirefoxDriverLogLevel.Info};
            var timeout = TimeSpan.FromSeconds(20);

            // workaround
            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var driver = new FirefoxDriver(service, options, timeout);
            return driver;
        }

        private FirefoxProfile CreateDefaultFirefoxProfile()
        {
            var profile = new FirefoxProfile();
            return profile;
        }
    }
}