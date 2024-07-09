using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class LoginPageSteps : BasePageSteps<LoginPage>
{
    public LoginPageSteps(string testName)
    {
        WebPage = new LoginPage(testName);
    }

    public void OpenLoginPage()
    {
        Log.Info("Opening Login Page");
        WebPage.Open(ConfigurationManager.GetConfiguration().WebUrl + "/login");
    }

    public void LoginWithCredentials(string login, string password)
    {
        Log.Info("Enter credentials and click login");
        WebPage.LoginTextbox.SendKeys(login);
        WebPage.PasswordTextbox.SendKeys(password);
        WebPage.LoginButton.Click();
        WebPage.WaitTillPageLoad();
        WebPage.WaitTillAjaxLoad();
    }

    public void ClickForgotPasswordLink()
    {
        throw new NotImplementedException("TODO: Not implemented!");
    }
}