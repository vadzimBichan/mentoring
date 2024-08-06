using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

public class LoginPageSteps : BasePageSteps<LoginPage>
{
    public void OpenLoginPage()
    {
        Log.Info("Opening Login Page");
        Page.Open(ConfigurationManager.GetConfiguration().WebUrl + "/login");
        Browser.WaitTillPageLoad();
    }

    public void LoginWithCredentials(string login, string password)
    {
        Log.Info("Enter credentials and click login");
        Page.SetLoginInputValue(login);
        Page.SetPasswordInputValue(password);
        Page.ClickLoginButton();
        Browser.WaitTillPageLoad();
        Browser.WaitTillAjaxLoad();
    }

    public void LoginWithTestUser()
    {
        var configuration = ConfigurationManager.GetConfiguration();
        LoginWithCredentials(configuration.TestUserLogin, configuration.TestUserPassword);
    }

    public void ClickForgotPasswordLink()
    {
        Page.ClickForgotPasswordLink();
    }
}