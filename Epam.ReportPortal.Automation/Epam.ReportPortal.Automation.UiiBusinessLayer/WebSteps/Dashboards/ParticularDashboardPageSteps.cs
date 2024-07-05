using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards
{
    public class ParticularDashboardPageSteps : BasePageSteps
    {
        private ParticularDashboardPage _particularDashboardPage;

        public ParticularDashboardPageSteps(TestConfiguration config) : base(config)
        {
            _particularDashboardPage = new ParticularDashboardPage(config);
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