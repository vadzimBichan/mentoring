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
        var result = new List<(string DashboardName, string DashboardDescription, string DashboardOwner)>();
        var rowsCount = DashboardsTable.GetRowsCount();
        for (var i = 0; i < rowsCount; i++)
        {
            result.Add((
                DashboardsTable.GetDashboardName(i),
                DashboardsTable.GetDashboardDescription(i),
                DashboardsTable.GetDashboardOwner(i)));
        }

        return result;
    }

    public void ClickAddNewDashboardButton()
    {
        AddNewDashboardButton.Click();
    }
}