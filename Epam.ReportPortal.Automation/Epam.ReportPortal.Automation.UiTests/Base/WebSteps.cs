using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

public class WebSteps
{
    public readonly TestConfiguration TestConfiguration;

    public WebSteps()
    {
        TestConfiguration = TestConfiguration.GetConfiguration();
    }

    // public BrowserSteps BrowserSteps => new BrowserSteps(config);

    public LoginPageSteps LoginPageSteps => new LoginPageSteps(TestConfiguration);

    public AllDashboardsPageSteps AllDashboardsSteps => new AllDashboardsPageSteps(TestConfiguration);

    public ParticularDashboardPageSteps ParticularDashboardSteps => new ParticularDashboardPageSteps(TestConfiguration);
}