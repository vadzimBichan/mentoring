using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Elements;

public class TableBase : WebComponent
{
    public TableBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }
}