using Epam.ReportPortal.Automation.Configuration.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Concurrent;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

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

        newBrowser.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
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

    public void Back()
    {
        Driver.Navigate().Back();
    }

    public void Forward()
    {
        Driver.Navigate().Forward();
    }

    public void Refresh()
    {
        Driver.Navigate().Refresh();
        WaitTillPageLoad();
    }

    public void ClearCookies()
    {
        Driver.Manage().Cookies.DeleteAllCookies();
    }

    /// <summary>
    ///     Scroll whole page to Top
    /// </summary>
    public void ScrollTop()
    {
        ExecuteScript("$(window).scrollTop(0)");
        WaitTillAjaxLoad();
    }

    /// <summary>
    ///     Scroll whole page to Bottom
    /// </summary>
    public void ScrollBottom()
    {
        ExecuteScript("$(window).scrollTop($(document).height())");
        WaitTillAjaxLoad();
    }

    public void ScrollToElement(IWebElement element)
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public bool WaitTillPageLoad(int numberOfSeconds = 10)
    {
        try
        {
            Wait(numberOfSeconds).Until(driver =>
            {
                try
                {
                    return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString()
                        .Contains("complete");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            });
        }
        catch (WebDriverTimeoutException)
        {
            // page is not loaded (other exceptions are caught)
        }

        return false;
    }

    public bool WaitTillAjaxLoad(int numberOfSeconds = 10)
    {
        try
        {
            Wait(numberOfSeconds).Until(driver =>
            {
                try
                {
                    return (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                        "return (typeof jQuery != 'undefined') && (jQuery.active === 0)");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            });
        }
        catch (WebDriverTimeoutException)
        {
            // page is not loaded (other exceptions are caught)
        }

        return false;
    }

    public WebDriverWait Wait(int numberOfSeconds = 10)
    {
        return new WebDriverWait(Driver, TimeSpan.FromSeconds(numberOfSeconds));
    }

    public object ExecuteScript(string script, params object[] args)
    {
        try
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(script, args);
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine(
                $"Error: Exception thrown while running JS Script:{Environment.NewLine}  {script}"); // todo: use logger
        }

        return null;
    }

    public object ExecuteAsyncScript(string script, params object[] args)
    {
        try
        {
            return ((IJavaScriptExecutor)Driver).ExecuteAsyncScript(script, args);
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine(
                $"Error: Exception thrown while running JS Script:{Environment.NewLine}  {script}"); // todo: use logger
        }

        return null;
    }

    public Screenshot GetScreenshot => ((ITakesScreenshot)Driver).GetScreenshot();
}