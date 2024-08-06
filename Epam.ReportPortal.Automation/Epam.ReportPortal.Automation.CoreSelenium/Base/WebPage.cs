using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public abstract class WebPage
{
    public readonly IWebDriver Driver = Browser.GetInstance().Driver;

    public string GetUrl()
    {
        return Driver.Url;
    }

    public string GetTitle()
    {
        return Driver.Title;
    }

    public WebPage Open(string url, bool switchToDefaultContent = false)
    {
        Driver.Navigate().GoToUrl(url);
        if (switchToDefaultContent) Driver.SwitchTo().DefaultContent();

        return this;
    }

    public void Close()
    {
        Driver.Quit();
    }
    public void ClickViaJs(IWebElement element)
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
    }
}