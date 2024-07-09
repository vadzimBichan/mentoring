using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class ParticularDashboardPageSteps : BasePageSteps<ParticularDashboardPage>
{

    public ParticularDashboardPageSteps(string testName)
    {
        WebPage = new ParticularDashboardPage(testName);
    }

    public void OpenParticularDashboardPage(string dashboardName)
    {
        throw new NotImplementedException("TODO: Not implemented!");
    }

    public int GetWidgetsCount()
    {
        return -1;
    }
}