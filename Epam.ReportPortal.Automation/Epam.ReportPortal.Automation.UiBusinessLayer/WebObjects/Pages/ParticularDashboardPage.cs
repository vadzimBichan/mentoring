using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class ParticularDashboardPage : BaseWebPage
{
    public LeftPanelComponent LeftPanel = new ();

    public IWebElement AddNewWidgetButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add new widget')]"));

    public IWebElement EditDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]"));

    public IWebElement DeleteDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Delete')]"));
}