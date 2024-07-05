using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages
{
    public class AllDashboardsPage : BaseWebPage
    {
        public LeftPanelComponent LeftPanel;

        public IWebElement AddNewDashboardButton => Driver.FindElement(By.CssSelector("div[class*='addDashboardButton']>button"));
        public IReadOnlyList<IWebElement> DashboardsList => Driver.FindElements(By.CssSelector("div[class*='gridRow__grid-row'][data-id]"));

        public IWebElement NameTextbox => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Enter dashboard name']"));
        public IWebElement DescriptionTextbox => Driver.FindElement(By.CssSelector("textarea[placeholder='Enter dashboard description']"));
        public IWebElement AddButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add')]"));
        public IWebElement CancelButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));

        public AllDashboardsPage(TestConfiguration config) : base(config)
        {
            LeftPanel = new LeftPanelComponent(config);
        }
    }
}
