using Epam.ReportPortal.Automation.CoreSelenium.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;

public class DeleteDashboardDialog : DeleteModalBase
{
    private IWebElement MessageElement => GetRootElement.FindElement(By.CssSelector("p[class*='deleteItemsModal__message']"));

    public DeleteDashboardDialog(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    private string GetMessageText()
    {
        return MessageElement.Text;
    }
}