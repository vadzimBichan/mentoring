using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class AllDashboardsPage : WebPage
{
    public LeftSidebarComponent SidebarMenu => new LeftSidebarComponent(Driver, By.Id("TODO"));

    public AddDashboardDialog AddDashboardDialog => new AddDashboardDialog(Driver, By.Id("TODO"));

    private IWebElement AddNewDashboardButton => Driver.FindElement(By.CssSelector("div[class*='addDashboardButton']>button"));
    
    private IReadOnlyList<IWebElement> DashboardsList => Driver.FindElements(By.CssSelector("div[class*='gridRow__grid-row'][data-id]"));

    public List<(string DashboardName, string DashboardDescription, string DashboardOwner)> GetDashboards()
    {
        return DashboardsList.Select(row => (
            row.FindElement(By.XPath(".//a[contains(@class, 'dashboardTable__name')]")).Text,
            row.FindElement(By.XPath(".//div[contains(@class, 'dashboardTable__description')]")).Text,
            row.FindElement(By.XPath(".//div[contains(@class, 'dashboardTable__owner')]")).Text)).ToList();
    }

    public void ClickAddNewDashboardButton()
    {
        AddNewDashboardButton.Click();
    }
}