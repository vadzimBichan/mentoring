using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;

public class WidgetsContainer : WebComponent
{
    private static readonly By WidgetLocator = By.CssSelector("[class*='widget__widget-container']");

    public WidgetsContainer(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public List<IWebElement> GetWidgets()
    {
        return GetRootElement.FindElements(WidgetLocator).ToList();
    }

    public int GetWidgetsCount()
    {
        return GetWidgets().Count;
    }
}