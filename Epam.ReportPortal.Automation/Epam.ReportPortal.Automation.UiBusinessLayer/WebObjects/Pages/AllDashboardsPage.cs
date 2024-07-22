using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class AllDashboardsPage : BaseWebPage
{
    public LeftPanelComponent LeftPanel = new();

    public IWebElement AddNewDashboardButton => Driver.FindElement(By.CssSelector("div[class*='addDashboardButton']>button"));

    public IReadOnlyList<IWebElement> DashboardsList => Driver.FindElements(By.CssSelector("div[class*='gridRow__grid-row'][data-id]"));

    public IWebElement AddNewDashboardDialogHeader => Driver.FindElement(By.CssSelector("span[class*='modalHeader__modal-title']"));

    public IWebElement NameInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Enter dashboard name']"));

    public IWebElement DescriptionInput => Driver.FindElement(By.CssSelector("textarea[placeholder='Enter dashboard description']"));

    public IWebElement AddButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add')]"));

    public IWebElement CancelButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));

    public List<(string DashboardName, string DashboardDescription, string DashboardOwner)> GetDashboards()
    {
        var dashboards = new List<(string DashboardName, string DashboardDescription, string DashboardOwner)>();
        foreach (var row in DashboardsList)
            dashboards.Add((
                row.FindElement(By.XPath(".//a[contains(@class, 'dashboardTable__name')]")).Text,
                row.FindElement(By.XPath(".//div[contains(@class, 'dashboardTable__description')]")).Text,
                row.FindElement(By.XPath(".//div[contains(@class, 'dashboardTable__owner')]")).Text));

        return dashboards;
    }
}