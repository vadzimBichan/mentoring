using Epam.ReportPortal.Automation.Configuration.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Concurrent;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public class Browser
{
    private static readonly ConcurrentDictionary<string, Browser> Instances
        = new ConcurrentDictionary<string, Browser>();

    public IWebDriver Driver { get; private set; }

    public static Browser GetInstance(string testName)
    {
        return Instances.GetOrAdd(testName, _ => CreateNewBrowserInstance());
    }

    private static Browser CreateNewBrowserInstance()
    {
        var configuration = TestConfiguration.GetConfiguration();
        Browser newBrowser = new Browser();
        switch (configuration.BrowserType)
        {
            case "Chrome":
                newBrowser.Driver = new ChromeDriver();
                break;
            case "Firefox":
                newBrowser.Driver = new FirefoxDriver();
                break;
            default:
                throw new Exception("The browser is not supported");
        }

        newBrowser.Driver.Manage().Window.Maximize();
        return newBrowser;
    }

    public static void Close(string testName)
    {
        if (Instances.TryRemove(testName, out var browser))
        {
            browser.Driver.Quit();
        }
    }
}