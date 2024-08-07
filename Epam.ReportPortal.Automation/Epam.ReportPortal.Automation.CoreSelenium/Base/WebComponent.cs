using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base;

public abstract class WebComponent
{
    private const int WaitSeconds = 5;
    private readonly By _rootLocator;

    protected readonly IWebDriver Driver;

    protected IWebElement GetRootElement => Driver.FindElement(_rootLocator);

    protected WebComponent(IWebDriver driver, By rootLocator)
    {
        Driver = driver;
        _rootLocator = rootLocator;
    }

    public void WaitElementVisibility(int seconds = WaitSeconds)
    {
        // todo: wait after ajax is completed
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.ElementIsVisible(_rootLocator));
    }

    public void WaitElementInvisibility(int seconds = WaitSeconds)
    {
        // todo: wait after ajax is completed
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_rootLocator));
    }
}