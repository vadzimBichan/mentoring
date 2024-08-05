using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;

public class LeftSidebarComponent : WebComponent
{
    private IWebElement DashboardsItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Dashboards']]"));

    private IWebElement LaunchesItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Launches']]"));

    private IWebElement FiltersItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Filters']]"));

    private IWebElement ProjectSettingsItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Project settings']]"));

    public LeftSidebarComponent(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickDashboardsItem()
    {
        DashboardsItem.Click();
    }

    public void ClickLaunchesItem()
    {
        LaunchesItem.Click();
    }

    public void ClickFiltersItem()
    {
        FiltersItem.Click();
    }

    public void ClickProjectSettingsItem()
    {
        ProjectSettingsItem.Click();
    }
}