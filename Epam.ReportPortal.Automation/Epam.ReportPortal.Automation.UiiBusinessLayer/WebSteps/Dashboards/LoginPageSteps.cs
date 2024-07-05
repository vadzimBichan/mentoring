using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards;

public class LoginPageSteps : BasePageSteps<LoginPage>
{
    public void OpenLoginPage()
    {
        WebPage.Open(TestConfiguration.GetConfiguration().Url + "/login");
    }

    public void LoginWithCredentials(string login, string password)
    {
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