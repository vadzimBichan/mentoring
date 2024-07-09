using Epam.ReportPortal.Automation.Configuration.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public class Browser
{
    private static Browser _instance;
    public IWebDriver Driver { get; }
    private static readonly object _lock = new();

    public static Browser GetInstance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = new Browser();
                return _instance;
            }
        }
    }

    private Browser()
    {
        var configuration = ConfigurationManager.GetConfiguration();
        switch (configuration.BrowserType)
        {
            case "Chrome":
                Driver = new ChromeDriver();
                break;
            case "Firefox":
                Driver = new FirefoxDriver();
                break;
            default:
                throw new Exception("The browser is not supported");
        }

        Driver.Manage().Window.Maximize();
    }

    public void Close()
    {
        Driver.Quit();
        _instance = null;
    }
}