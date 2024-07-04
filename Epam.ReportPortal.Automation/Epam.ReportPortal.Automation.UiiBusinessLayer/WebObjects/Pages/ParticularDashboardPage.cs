using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages
{
    public class ParticularDashboardPage : BaseWebPage
    {
        public LeftPanelComponent LeftPanel => new LeftPanelComponent(Browser);


        public IWebElement AddNewWidgetButton => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement EditDashboardButton => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement DeleteDashboardButton => Browser.Driver.FindElement(By.CssSelector("TODO"));

        // TODO: other important  web elements

        public ParticularDashboardPage(Browser browser) : base(browser)
        {
        }
    }
}
