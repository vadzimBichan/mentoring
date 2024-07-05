using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards
{
    public class AllDashboardsPageSteps : BasePageSteps
    {
        private AllDashboardsPage _allDashboardsPage;

        public AllDashboardsPageSteps(TestConfiguration config) : base(config)
        {
            _allDashboardsPage = new AllDashboardsPage(config);
        }
        
        public void OpenAllDashboardsPage()
        {
            _allDashboardsPage.LeftPanel.DashboardsItem.Click();

            Thread.Sleep(1000);
        }

        public List<string> GetDashboards()
        {
            var dashboards = new List<string>();
            foreach (var dashboard in _allDashboardsPage.DashboardsList)
            {
                dashboards.Add(dashboard.Text);
            }

            return dashboards;
        }

        public int GetDashboardsCount()
        {
            return GetDashboards().Count;
        }

        public void CreateDashboard(string dashboardName, string dashboardDescription)
        {
            _allDashboardsPage.AddNewDashboardButton.Click();
            _allDashboardsPage.NameTextbox.SendKeys(dashboardName); 
            _allDashboardsPage.DescriptionTextbox.SendKeys(dashboardDescription);
            _allDashboardsPage.AddButton.Click();
        }
    }
}