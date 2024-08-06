using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class ParticularDashboardPageSteps : BasePageSteps<ParticularDashboardPage>
{
    public void CloseEditDashboardDialog()
    {
        Log.Info("Closing edit dashboard dialog");

        Page.EditDashboardDialog.CLickClose();
        Page.WaitTillAjaxLoad();
    }

    public bool IsDeleteDashboardDialogOpened()
    {
        Log.Info("Getting delete dialog visibility");

        return Page.DeleteDashboardDialog.IsDialogVisible();
    }

    public void CloseDeleteDashboardDialog()
    {
        Log.Info("Closing delete dashboard dialog");

        Page.DeleteDashboardDialog.CLickClose();
        Page.WaitTillAjaxLoad();
    }

    public bool IsEditDashboardDialogOpened()
    {
        Log.Info("Getting edit dialog visibility");

        return Page.EditDashboardDialog.IsDialogVisible();
    }

    public int GetWidgetsCount()
    {
        Log.Info("Getting widgets count");

        return Page.WidgetsContainer.GetWidgetsCount();
    }

    public string GetDashboardNameInBreadcrumbs()
    {
        Log.Info("Getting dashboard name in breadcrumbs");

        return Page.GetDashboardNameInBreadcrumbs();
    }

    public void EditDashboardNameAndDescription(string? newDashboardName = null, string? newDashboardDescription = null)
    {
        Log.Info("Updating dashboard name and description");

        Page.ClickEditDashboardButton();
        if (newDashboardName != null)
        {
            Page.EditDashboardDialog.SetNameInputValue(newDashboardName);
        }

        if (newDashboardDescription != null)
        {
            Page.EditDashboardDialog.SetDescriptionInputValue(newDashboardDescription);
        }
        Page.EditDashboardDialog.ClickUpdate();
        Page.WaitTillAjaxLoad();
    }

    public void DeleteDashboard()
    {
        Log.Info("Deleting dashboard");

        TryDeleteDashboard();
        Page.DeleteDashboardDialog.ClickDelete(); // confirm delete
        Page.WaitTillPageLoad();
        Page.WaitTillAjaxLoad();
    }

    public void TryDeleteDashboard()
    {
        Log.Info("Deleting dashboard");

        Page.ClickDeleteDashboardButton();
        Page.WaitTillAjaxLoad();
    }
}