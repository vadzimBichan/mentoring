using Epam.ReportPortal.Automation.CoreSelenium.Elements;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;

public class DashboardsTable : TableBase
{
    public DashboardsTable(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public string GetDashboardName(int rowIndex)
    {
        return GetValueFromCell(rowIndex, (int)DashboardColumns.Name);
    }

    public string GetDashboardDescription(int rowIndex)
    {
        return GetValueFromCell(rowIndex, (int)DashboardColumns.Description);
    }

    public string GetDashboardOwner(int rowIndex)
    {
        return GetValueFromCell(rowIndex, (int)DashboardColumns.Owner);
    }

    public void ClickDashboardLink(string dashboardName)
    {
        var dashboards = GetDashboards();
        var rowIndex = dashboards.FindIndex(d => d.DashboardName.Equals(dashboardName));
        ClickDashboardLink(rowIndex);
    }

    public void ClickDashboardLink(int index)
    {
        ClickCell(index, (int)DashboardColumns.Name);
    }

    public void ClickEditDashboard(string dashboardName)
    {
        var dashboards = GetDashboards();
        var rowIndex = dashboards.FindIndex(d => d.DashboardName.Equals(dashboardName));
        ClickEditDashboard(rowIndex);
    }

    public void ClickEditDashboard(int index)
    {
        ClickCell(index, (int)DashboardColumns.Edit);
    }

    public void ClickDeleteDashboard(string dashboardName)
    {
        var dashboards = GetDashboards();
        var rowIndex = dashboards.FindIndex(d => d.DashboardName.Equals(dashboardName));
        ClickDeleteDashboard(rowIndex);
    }

    public void ClickDeleteDashboard(int index)
    {
        ClickCell(index, (int)DashboardColumns.Delete);
    }

    public List<(string DashboardName, string DashboardDescription, string DashboardOwner)> GetDashboards()
    {
        var result = new List<(string DashboardName, string DashboardDescription, string DashboardOwner)>();
        var rowsCount = GetRowsCount();
        for (var i = 0; i < rowsCount; i++)
            result.Add((
                GetDashboardName(i),
                GetDashboardDescription(i),
                GetDashboardOwner(i)));

        return result;
    }
}

public enum DashboardColumns
{
    Name,
    Description,
    Owner,
    Edit,
    Delete
}