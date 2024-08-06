using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Models;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class AllDashboardsPageSteps : BasePageSteps<AllDashboardsPage>
{
    public void OpenAllDashboardsPage()
    {
        Log.Info("Opening all dashboards");
        Page.SidebarMenu.ClickDashboardsItem();
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public void OpenParticularDashboardPage(string dashboardName)
    {
        Log.Info("Opening particular dashboard page");
        Page.DashboardsTable.ClickDashboardLink(dashboardName);
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
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
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public void DeleteDashboardInTable(string dashboardName)
    {
        Log.Info("Deleting dashboard");
        TryDeleteDashboardInTable(dashboardName);
        Page.DeleteDashboardDialog.ClickDelete(); // confirm delete
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public void TryDeleteDashboardInTable(string dashboardName)
    {
        Log.Info("Deleting dashboard");
        Page.DashboardsTable.ClickDeleteDashboard(dashboardName);
        Browser.WaitTillAjaxLoad();
    }

    public void UpdateDashboardInTable(string dashboardName, string newDashboardName, string newDashboardDescription)
    {
        Log.Info("Updating dashboard");
        TryUpdateDashboardInTable(dashboardName, newDashboardName, newDashboardDescription);
        Page.EditDashboardDialog.ClickUpdate(); // confirm update
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public void TryUpdateDashboardInTable(string dashboardName, string newDashboardName, string newDashboardDescription)
    {
        Log.Info("Updating dashboard");
        Page.DashboardsTable.ClickEditDashboard(dashboardName);
        Page.EditDashboardDialog.SetNameInputValue(newDashboardName);
        Page.EditDashboardDialog.SetDescriptionInputValue(newDashboardDescription);
        Browser.WaitTillAjaxLoad();
    }

    public void CloseAddNewDashboardDialog()
    {
        Log.Info("Closing new dashboard dialog");
        Page.AddDashboardDialog.ClickCancel();
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public bool IsAddNewDashboardDialogOpened()
    {
        Log.Info("Getting new dashboard dialog visibility");

        return Page.AddDashboardDialog.IsDialogVisible();
    }

    public void CloseDeleteDashboardDialog()
    {
        Log.Info("Closing delete dashboard dialog");
        Page.DeleteDashboardDialog.ClickCancel();
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public bool IsDeleteDashboardDialogOpened()
    {
        Log.Info("Getting delete dashboard dialog visibility");

        return Page.DeleteDashboardDialog.IsDialogVisible();
    }

    public void CloseEditDashboardDialog()
    {
        Log.Info("Closing edit dashboard dialog");
        Page.EditDashboardDialog.ClickCancel();
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public bool IsEditDashboardDialogOpened()
    {
        Log.Info("Getting edit dashboard dialog visibility");

        return Page.EditDashboardDialog.IsDialogVisible();
    }

    public List<Dashboard> GetDashboards()
    {
        return Page.GetDashboards().Select(tuple => new Dashboard(tuple.DashboardName, tuple.DashboardDescription, tuple.DashboardOwner)).ToList();
    }
}