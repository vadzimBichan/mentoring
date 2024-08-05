using Epam.ReportPortal.Automation.CoreSelenium.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;

public class DeleteDashboardDialog : DeleteModalBase
{
    public DeleteDashboardDialog(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }
}