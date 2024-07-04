using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.Core.Selenium.Factory
{
    public interface IWebDriverFactory
    {
        public IWebDriver? Create();
    }
}
