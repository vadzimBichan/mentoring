using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Pages;

public class LoginPage : BaseWebPage
{
    public IWebElement LoginTextbox => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Login']"));

    public IWebElement PasswordTextbox => Driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password']"));

    public IWebElement LoginButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Login')]"));

    public LoginPage(TestConfiguration config) : base(config)
    {
    }
}