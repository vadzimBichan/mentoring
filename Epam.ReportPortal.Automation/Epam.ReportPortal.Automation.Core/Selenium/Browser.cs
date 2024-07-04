using Epam.ReportPortal.Automation.Core.Selenium.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Epam.ReportPortal.Automation.Core.Selenium
{
    public class Browser
    {
        private readonly IWebDriverFactory _driverFactory;
        private IWebDriver? _driver;

        public IWebDriver? Driver => _driver ??= _driverFactory.Create();

        public Browser(IWebDriverFactory factory)
        {
            _driverFactory = factory;
        }

        public string GetUrl()
        {
            return Driver.Url;
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        public Browser Back()
        {
            Driver.Navigate().Back();
            return this;
        }

        public Browser Forward()
        {
            Driver.Navigate().Forward();
            return this;
        }

        public Browser Refresh()
        {
            Driver.Navigate().Refresh();
            WaitTillPageLoad();
            return this;
        }

        public Browser Maximize()
        {
            Driver.Manage().Window.Maximize();
            return this;
        }

        public Browser ClearCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            return this;
        }

        public Browser Open(string url, bool switchToDefaultContent = false)
        {
            Driver.Navigate().GoToUrl(url);
            WaitTillPageLoad();
            if (switchToDefaultContent) Driver.SwitchTo().DefaultContent();

            return this;
        }

        public void SwitchToWindowHandle(string windowHandle)
        {
            Driver.SwitchTo().Window(windowHandle);
        }

        public void SwitchToWindowHandleByUrl(string urlPart)
        {
            if (GetUrl().Contains(urlPart)) return;

            var handles = Driver.WindowHandles;
            foreach (var handle in handles.Reverse())
            {
                Driver.SwitchTo().Window(handle);
                if (GetUrl().Contains(urlPart))
                {
                    WaitTillPageLoad();
                    WaitTillAjaxLoad();
                    return;
                }
            }
        }

        public void CloseCurrentTab()
        {
            Driver.Close();
        }

        public void Quit()
        {
            if (_driver == null) return;
            try
            {
                foreach (var window in Driver.WindowHandles)
                {
                    Driver.SwitchTo().Window(window);
                    CloseCurrentTab();
                }

                Driver.Quit();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Unable to Quit the browser. Reason: {ex.Message}"); // todo: use logger
            }

            finally
            {
                _driver = null;
            }
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
                        return (bool) ((IJavaScriptExecutor) driver).ExecuteScript(
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
                return ((IJavaScriptExecutor) Driver).ExecuteScript(script, args);
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
                return ((IJavaScriptExecutor) Driver).ExecuteAsyncScript(script, args);
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine(
                    $"Error: Exception thrown while running JS Script:{Environment.NewLine}  {script}"); // todo: use logger
            }

            return null;
        }

        public Screenshot GetScreenshot => ((ITakesScreenshot) Driver).GetScreenshot();
    }
}