using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public abstract class BaseWebPage
{
    public readonly IWebDriver Driver; 

    protected BaseWebPage(Configuration.Settings.TestConfiguration config)
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

    public string GetUrl()
    {
        return Driver.Url;
    }

    public string GetTitle()
    {
        return Driver.Title;
    }

    public BaseWebPage Back()
    {
        Driver.Navigate().Back();
        return this;
    }

    public BaseWebPage Forward()
    {
        Driver.Navigate().Forward();
        return this;
    }

    public BaseWebPage Refresh()
    {
        Driver.Navigate().Refresh();
        WaitTillPageLoad();
        return this;
    }

    public BaseWebPage ClearCookies()
    {
        Driver.Manage().Cookies.DeleteAllCookies();
        return this;
    }

    public BaseWebPage Open(string url, bool switchToDefaultContent = false)
    {
        Driver.Navigate().GoToUrl(url);
        WaitTillPageLoad();
        if (switchToDefaultContent) Driver.SwitchTo().DefaultContent();

        return this;
    }

    public void CloseCurrentTab()
    {
        Driver.Close();
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