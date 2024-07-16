using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class ParticularDashboardPageSteps : BasePageSteps<ParticularDashboardPage>
{
    public void CloseEditDashboardDialog()
    {
        Log.Info("Closing edit dashboard dialog");
        WebPage.CancelButton.Click();
        WebPage.WaitTillPageLoad();
        WebPage.WaitTillAjaxLoad();
    }

    public bool IsEditDashboardDialogOpened()
    {
        Log.Info("Checking edit dialog visibility");
        try
        {
            return WebPage.EditDashboardDialogHeader.Displayed;
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

    public int GetWidgetsCount()
    {
        Log.Info("Getting widgets count");
        return -1;
    }

    public void CheckDashboardNameInBreadcrumbs(string expectedDashboardName)
    {
        Log.Info("Checking dashboard name in breadcrumbs");
        var actualDashboardName = WebPage.DashboardNameLabel.Text;
        Assert.That(actualDashboardName, Is.EqualTo(expectedDashboardName.ToUpper()),
            $"Dashboard name in breadcrumbs should be '{expectedDashboardName.ToUpper()}', but it is '{actualDashboardName}'");
    }

    public void EditDashboardNameAndDescription(string? newDashboardName = null, string? newDashboardDescription = null)
    {
        Log.Info("Updating dashboard name and description");
        WebPage.EditDashboardButton.Click();
        if (newDashboardName != null)
        {
            WebPage.NameInput.Clear();
            WebPage.NameInput.SendKeys(newDashboardName);
        }

        if (newDashboardDescription != null)
        {
            WebPage.DescriptionInput.Clear();
            WebPage.DescriptionInput.SendKeys(newDashboardDescription);
        }
        WebPage.UpdateButton.Click();
        WebPage.WaitTillAjaxLoad();
    }
}