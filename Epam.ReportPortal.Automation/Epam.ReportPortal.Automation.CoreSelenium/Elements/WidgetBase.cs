using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Elements;

public class WidgetBase : WebComponent
{
    public IWebElement WidgetHeader => GetRootElement.FindElement(By.CssSelector("div[class*='widgetHeader__widget-header']"));

    public IWebElement WidgetName => GetRootElement.FindElement(By.CssSelector("div[class*='widgetHeader__widget-name']"));

    public IWebElement WidgetType => GetRootElement.FindElement(By.CssSelector("div[class*='widgetHeader__widget-type']"));

    public IWebElement GraphicArea=> GetRootElement.FindElement(By.CssSelector("div[class*='widget__widget--']"));

    public WidgetBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public string GetWidgetName()
    {
        return WidgetName.Text;
    }

    public string GetWidgetType()
    {
        return WidgetType.Text;
    }
}