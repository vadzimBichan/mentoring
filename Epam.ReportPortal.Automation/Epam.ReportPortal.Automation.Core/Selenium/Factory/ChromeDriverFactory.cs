using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Epam.ReportPortal.Automation.Core.Selenium.Factory
{
    public class ChromeDriverFactory: IWebDriverFactory 
    {
        public IWebDriver? Create()
        {
            var service = ChromeDriverService.CreateDefaultService("TODO");
            var options = CreateDefaultChromeOptions();
            var timeout = TimeSpan.FromSeconds(20);
            var driver = new ChromeDriver(service, options, timeout);
            return driver;
        }

        public static ChromeOptions CreateDefaultChromeOptions()
        {
            var options = new ChromeOptions();
            return options;
        }
    }
}
