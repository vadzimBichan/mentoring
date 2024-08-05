using Epam.ReportPortal.Automation.Configuration.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Concurrent;
using NUnit.Framework;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public class Browser
{
    private static readonly ConcurrentDictionary<string, Browser> Instances = new();

    public IWebDriver Driver { get; private set; }

    public static Browser GetInstance()
    {
        return Instances.GetOrAdd(TestContext.CurrentContext.Test.FullName, _ => CreateNewBrowserInstance());
    }

    private static Browser CreateNewBrowserInstance()
    {
        var configuration = ConfigurationManager.GetConfiguration();
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

        newBrowser.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        newBrowser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        newBrowser.Driver.Manage().Window.Maximize();
        
        return newBrowser;
    }

    public static void Close()
    {
        if (Instances.TryRemove(TestContext.CurrentContext.Test.FullName, out var browser))
        {
            browser.Driver.Quit();
        }
    }
}