using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages
{
    public class ParticularDashboardPage : BaseWebPage
    {
        public LeftPanelComponent LeftPanel;


        public IWebElement AddNewWidgetButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add new widget')]"));

        public IWebElement EditDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Edit')]"));

        public IWebElement DeleteDashboardButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Delete')]"));

        // TODO: other important  web elements

        public ParticularDashboardPage(TestConfiguration config) : base(config)
        {
            LeftPanel = new LeftPanelComponent(config);
        }
    }
}
