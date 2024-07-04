using Epam.ReportPortal.Automation.BusinessLayer.UiObjects.Components;
using Epam.ReportPortal.Automation.Core.Selenium;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.BusinessLayer.UiObjects.Pages
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
