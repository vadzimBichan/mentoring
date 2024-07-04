using Epam.ReportPortal.Automation.BusinessLayer.UiObjects.Pages;
using Epam.ReportPortal.Automation.Core.Selenium;

namespace Epam.ReportPortal.Automation.BusinessLayer.UiSteps.Dashboards
{
    public class ParticularDashboardPageSteps : BasePageSteps
    {
        private ParticularDashboardPage _particularDashboardPage;

        public ParticularDashboardPageSteps(Browser browser) : base(browser)
        {
            _particularDashboardPage = new ParticularDashboardPage(browser);
        }
        
        public void OpenParticularDashboardPage(string dashboardName)
        {
            // TODO
        }

        public List<string> GetWidgets()
        {
            // TODO
            return null;
        }

        public int GetWidgetsCount()
        {
            // TODO
            return -1;
        }
    }
}