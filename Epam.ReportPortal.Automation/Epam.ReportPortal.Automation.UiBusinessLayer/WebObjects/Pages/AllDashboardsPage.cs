using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class AllDashboardsPage : WebPage
{
    public LeftSidebarComponent SidebarMenu => new LeftSidebarComponent(Driver, By.CssSelector("aside[class*='sidebar__sidebar']"));

    public AddDashboardDialog AddDashboardDialog => new AddDashboardDialog(Driver, By.CssSelector("div[class*='modalLayout__modal-window']"));

    public EditDashboardDialog EditDashboardDialog => new(Driver, By.CssSelector("div[class*='modalLayout__modal-window']")); // via table

    public DeleteDashboardDialog DeleteDashboardDialog => new(Driver, By.CssSelector("div[class*='modalLayout__modal-window']")); // via table

    public DashboardsTable DashboardsTable => new DashboardsTable(Driver, By.CssSelector("div[class*='dashboardTable__dashboard-table']"));

    private IWebElement AddNewDashboardButton => Driver.FindElement(By.CssSelector("div[class*='addDashboardButton']>button"));

    public List<(string DashboardName, string DashboardDescription, string DashboardOwner)> GetDashboards()
    {
        return DashboardsTable.GetDashboards();
    }

    public void ClickAddNewDashboardButton()
    {
        AddNewDashboardButton.Click();
    }
}