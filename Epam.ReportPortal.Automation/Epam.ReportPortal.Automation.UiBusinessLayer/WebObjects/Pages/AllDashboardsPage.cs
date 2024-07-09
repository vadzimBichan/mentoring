using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class AllDashboardsPage : BaseWebPage
{
    public LeftPanelComponent LeftPanel = new();

    public IWebElement AddNewDashboardButton => Driver.FindElement(By.CssSelector("div[class*='addDashboardButton']>button"));

    public IReadOnlyList<IWebElement> DashboardsList => Driver.FindElements(By.CssSelector("div[class*='gridRow__grid-row'][data-id]"));

    public IWebElement NewDashboardDialogHeader => Driver.FindElement(By.CssSelector("span[class*='modalHeader__modal-title']"));

    public IWebElement NameInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Enter dashboard name']"));

    public IWebElement DescriptionInput => Driver.FindElement(By.CssSelector("textarea[placeholder='Enter dashboard description']"));

    public IWebElement AddButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add')]"));

    public IWebElement CancelButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));
}