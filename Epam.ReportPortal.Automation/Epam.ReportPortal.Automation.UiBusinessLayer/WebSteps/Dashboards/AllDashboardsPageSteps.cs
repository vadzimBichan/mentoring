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

    public void OpenParticularDashboardPage(string dashboardName)
    {
        Log.Info("Checking particular dashboard paage");
        throw new NotImplementedException("TODO: Not implemented!");
    }

    public int CreateDashboard(string dashboardName, string dashboardDescription)
    {
        Log.Info("Creating new dashboard");
        WebPage.AddNewDashboardButton.Click();
        WebPage.NameInput.SendKeys(dashboardName);
        WebPage.DescriptionInput.SendKeys(dashboardDescription);
        WebPage.AddButton.Click();
        WebPage.WaitTillPageLoad();
        WebPage.WaitTillAjaxLoad();

        return int.Parse(WebPage.GetUrl().Split('/').Last()); // return dashboard id from url
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
            return WebPage.AddNewDashboardDialogHeader.Displayed;
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

    public List<(string Name, string Description, string Owner)> GetDashboards()
    {
        return WebPage.GetDashboards();
    }

    public int GetDashboardsCount()
    {
        return GetDashboards().Count;
    }
}