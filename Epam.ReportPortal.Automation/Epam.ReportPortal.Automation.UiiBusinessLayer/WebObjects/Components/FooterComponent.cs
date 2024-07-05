using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components;

public class LeftPanelComponent : BaseWebComponent
{
    public override IWebElement Root => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement DashboardsItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Dashboards']]"));

    public IWebElement LaunchesItem => Driver.FindElement(By.XPath("//div[contains(@class,'sidebarButton__sidebar-nav-btn') and .//span[text()='Launches']]"));

    public IWebElement FiltersItem => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement ProjectSettingsItem => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement UserIcon => Driver.FindElement(By.CssSelector("TODO"));
}