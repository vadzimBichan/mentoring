using Epam.ReportPortal.Automation.BusinessLayer.UiSteps.Dashboards;
using Epam.ReportPortal.Automation.Core.Selenium;

namespace Epam.ReportPortal.Automation.Tests.UiTests.Base
{
    public class WebSteps
    {
        private readonly Browser? _browser;

        public WebSteps(Browser? browser)
        {
            _browser = browser;
        }

        public AllDashboardsPageSteps AllDashboardsSteps => new AllDashboardsPageSteps(_browser);

        public ParticularDashboardPageSteps ParticularDashboardSteps => new ParticularDashboardPageSteps(_browser);
    }
}
