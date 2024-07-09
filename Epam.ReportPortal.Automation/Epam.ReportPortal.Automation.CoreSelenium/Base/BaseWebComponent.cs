using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public abstract class BaseWebComponent
{
    public readonly IWebDriver Driver;

    public abstract IWebElement Root { get; }

    protected BaseWebComponent(string testName)
    {
        Driver = Browser.GetInstance(testName).Driver;
    }
}