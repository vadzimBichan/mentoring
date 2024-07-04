using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages
{
    public class AllDashboardsPage : BaseWebPage
    {
        public LeftPanelComponent LeftPanel => new LeftPanelComponent(Browser);

        public IWebElement AddNewDashboardButton => Browser.Driver.FindElement(By.CssSelector("TODO"));

        // TODO: other important  web elements

        public AllDashboardsPage(Browser browser) : base(browser)
        {

        }
    }
}
