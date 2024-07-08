using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class LoginPage : BaseWebPage
{
    public IWebElement LoginTextbox => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Login']"));

    public IWebElement PasswordTextbox => Driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password']"));

    public IWebElement LoginButton => Driver.FindElement(By.CssSelector("div[class*='loginForm__login-button-container']>button"));
}