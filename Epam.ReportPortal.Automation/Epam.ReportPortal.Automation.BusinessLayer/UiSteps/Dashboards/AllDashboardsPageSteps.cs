using Epam.ReportPortal.Automation.BusinessLayer.UiObjects.Pages;
using Epam.ReportPortal.Automation.Core.Selenium;

namespace Epam.ReportPortal.Automation.BusinessLayer.UiSteps.Dashboards
{
    public class AllDashboardsPageSteps : BasePageSteps
    {
        private AllDashboardsPage _allDashboardsPage;

        public AllDashboardsPageSteps(Browser browser) : base(browser)
        {
            _allDashboardsPage = new AllDashboardsPage(browser);
        }
        
        public void OpenAllDashboardsPage()
        {
            // TODO
        }

        public List<string> GetDashboards()
        {
            // TODO
            return null;
        }

        public int GetDashboardsCount()
        {
            // TODO
            return -1;
        }
    }
}