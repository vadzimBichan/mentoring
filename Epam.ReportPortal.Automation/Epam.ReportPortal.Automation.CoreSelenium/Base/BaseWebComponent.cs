using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public abstract class BaseWebComponent
{
    public readonly IWebDriver Driver;

    public abstract IWebElement Root { get; }

    // Initialize WebDriver based on the Browser selection 
    protected BaseWebComponent(Configuration.Settings.TestConfiguration config)
    {
        switch (config.BrowserType)
        {
            case "Chrome":
                Driver = ChromeDriverSingleton.Instance;
                break;
            case "Firefox":
                Driver = FirefoxDriverSingleton.Instance;
                break;
            default:
                throw new Exception("The browser is not supported");
        }
    }
}
