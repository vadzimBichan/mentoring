using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps.Dashboards
{
    public class LoginPageSteps : BasePageSteps
    {
        private readonly LoginPage _loginPage;

        public LoginPageSteps(TestConfiguration config) : base(config)
        {
            _loginPage = new LoginPage(config);
        }
        
        public void OpenLoginPage()
        {
            _loginPage.Driver.Navigate().GoToUrl(Config.Url+ "/login");
        }

        public void LoginWithCredentials(string login, string password)
        {
            _loginPage.LoginTextbox.SendKeys(login);
            _loginPage.PasswordTextbox.SendKeys(password);
            _loginPage.LoginButton.Click();

            Thread.Sleep(1000);
        }

        public void ClickForgotPasswordLink()
        {
            // TODO
        }

    }
}