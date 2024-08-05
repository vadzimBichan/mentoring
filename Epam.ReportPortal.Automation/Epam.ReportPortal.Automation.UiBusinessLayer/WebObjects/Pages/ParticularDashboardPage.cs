using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class ParticularDashboardPage : WebPage
{
    public LeftSidebarComponent SidebarMenu => new(Driver, By.Id("TODO"));

    private IWebElement DashboardNameLabel => Driver.FindElement(By.XPath(
        "//ul[contains(@class, 'pageBreadcrumbs__page-breadcrumbs')]/li[contains(@class, 'pageBreadcrumbs__page-breadcrumbs-item')][2]/span"));

    private IWebElement AddNewWidgetButton =>
        Driver.FindElement(By.XPath("//button[contains(text(), 'Add new widget')]"));

    private IWebElement EditDashboardButton =>
        Driver.FindElement(By.XPath("//button[.//span[contains(text(), 'Edit')]]"));

    private IWebElement DeleteDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Delete')]"));

    public EditDashboardDialog EditDashboardDialog => new(Driver, By.Id("TODO"));

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