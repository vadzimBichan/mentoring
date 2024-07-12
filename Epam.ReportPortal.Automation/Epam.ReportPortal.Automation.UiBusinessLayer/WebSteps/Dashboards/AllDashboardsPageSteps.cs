using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;
using OpenQA.Selenium;

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
        WebPage.NameInput.SendKeys(dashboardName);
        WebPage.DescriptionInput.SendKeys(dashboardDescription);
        WebPage.AddButton.Click();
        WebPage.WaitTillPageLoad();
    }

    public void CloseAddNewDashboardDialog()
    {
        Log.Info("Closing new dashboard dialog");
        WebPage.CancelButton.Click();
        WebPage.WaitTillPageLoad();
        WebPage.WaitTillAjaxLoad();
    }

    public bool IsAddNewDashboardDialogOpened()
    {
        Log.Info("Checking new dashboard dialog visibility");
        try
        {
            return WebPage.NewDashboardDialogHeader.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
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