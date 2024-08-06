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
}

public enum DashboardColumns
{
    Name,
    Description,
    Owner
}