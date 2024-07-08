using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class AllDashboardsPageSteps : BasePageSteps<AllDashboardsPage>
{
    public void OpenAllDashboardsPage()
    {
        Log.Info("Opening all dashboards");
        WebPage.LeftPanel.DashboardsItem.Click();
        WebPage.WaitTillPageLoad();
    }

    public void CreateDashboard(string dashboardName, string dashboardDescription)
    {
        Log.Info("Creating new dashboard");
        WebPage.AddNewDashboardButton.Click();
        WebPage.NameTextbox.SendKeys(dashboardName);
        WebPage.DescriptionTextbox.SendKeys(dashboardDescription);
        WebPage.AddButton.Click();
        WebPage.WaitTillPageLoad();
    }

    public List<string> GetDashboards()
    {
        var dashboards = new List<string>();
        foreach (var dashboard in WebPage.DashboardsList)
        {
            dashboards.Add(dashboard.Text);
        }

        return dashboards;
    }

    public int GetDashboardsCount()
    {
        return GetDashboards().Count;
    }
}