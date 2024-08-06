using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class AllDashboardsPageSteps : BasePageSteps<AllDashboardsPage>
{
    public void OpenAllDashboardsPage()
    {
        Log.Info("Opening all dashboards");
        Page.SidebarMenu.ClickDashboardsItem();
        Page.WaitTillPageLoad();
    }

    public void OpenParticularDashboardPage(string dashboardName)
    {
        Log.Info("Checking particular dashboard page");
        throw new NotImplementedException("TODO: Not implemented!");
    }

    public int CreateDashboard(string dashboardName, string dashboardDescription)
    {
        Log.Info("Creating new dashboard");
        TryCreateDashboard(dashboardName, dashboardDescription);
        return int.Parse(Page.GetUrl().Split('/').Last()); // return dashboard id from url
    }

    public void TryCreateDashboard(string dashboardName, string dashboardDescription)
    {
        Log.Info("Creating new dashboard");
        Page.ClickAddNewDashboardButton();
        Page.AddDashboardDialog.SetNameInputValue(dashboardName);
        Page.AddDashboardDialog.SetDescriptionInputValue(dashboardDescription);
        Page.AddDashboardDialog.ClickAdd();
        Page.WaitTillPageLoad();
        Page.WaitTillAjaxLoad();
    }

    public void CloseAddNewDashboardDialog()
    {
        Log.Info("Closing new dashboard dialog");
        Page.AddDashboardDialog.ClickCancel();
        Page.WaitTillPageLoad();
        Page.WaitTillAjaxLoad();
    }

    public bool IsAddNewDashboardDialogOpened()
    {
        Log.Info("Getting new dashboard dialog visibility");

        return Page.AddDashboardDialog.IsDialogVisible();
    }

    public List<(string Name, string Description, string Owner)> GetDashboards()
    {
        return Page.GetDashboards();
    }

    public int GetDashboardsCount()
    {
        return GetDashboards().Count;
    }
}