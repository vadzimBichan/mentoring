using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class ParticularDashboardPage : WebPage
{
    public LeftSidebarComponent SidebarMenu => new(Driver, By.CssSelector("aside[class*='sidebar__sidebar']"));

    public AddDashboardDialog AddDashboardDialog => new(Driver, By.CssSelector("div[class*='modalLayout__modal-window']"));

    public EditDashboardDialog EditDashboardDialog => new(Driver, By.CssSelector("div[class*='modalLayout__modal-window']"));

    public DeleteDashboardDialog DeleteDashboardDialog => new(Driver, By.CssSelector("div[class*='modalLayout__modal-window']"));

    public WidgetsContainer WidgetsContainer => new WidgetsContainer(Driver, By.CssSelector("div[class*='widgets-grid']"));

    private IWebElement DashboardNameLabel => Driver.FindElement(By.XPath("//li[contains(@class, 'pageBreadcrumbs__page-breadcrumbs-item')]/span[@title]"));

    private IWebElement AddNewWidgetButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add new widget')]"));

    private IWebElement EditDashboardButton => Driver.FindElement(By.XPath("//button[.//span[contains(text(), 'Edit')]]"));

    private IWebElement DeleteDashboardButton => Driver.FindElement(By.XPath("//button[.//span[contains(text(), 'Delete')]]"));

    public void ClickAddNewWidgetButton()
    {
        AddNewWidgetButton.Click();
    }

    public void ClickEditDashboardButton()
    {
        EditDashboardButton.Click();
    }

    public void ClickDeleteDashboardButton()
    {
        DeleteDashboardButton.Click();
    }

    public string GetDashboardNameInBreadcrumbs()
    {
        return DashboardNameLabel.Text;
    }
}