using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class ParticularDashboardPage : BaseWebPage
{
    public LeftPanelComponent LeftPanel = new ();

    public IWebElement AddNewWidgetButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add new widget')]"));

    public IWebElement DashboardNameLabel => Driver.FindElement(By.XPath("//ul[contains(@class, 'pageBreadcrumbs__page-breadcrumbs')]/li[contains(@class, 'pageBreadcrumbs__page-breadcrumbs-item')][2]/span"));

    public IWebElement EditDashboardButton => Driver.FindElement(By.XPath("//button[.//span[contains(text(), 'Edit')]]"));

    public IWebElement DeleteDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Delete')]"));

    public IWebElement EditDashboardDialogHeader => Driver.FindElement(By.CssSelector("span[class*='modalHeader__modal-title']"));
    
    public IWebElement NameInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Enter dashboard name']"));

    public IWebElement DescriptionInput => Driver.FindElement(By.CssSelector("textarea[placeholder='Enter dashboard description']"));

    public IWebElement UpdateButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Update')]"));

    public IWebElement CancelButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));
}