using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class LoginPage : WebPage
{
    private IWebElement LoginInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Login']"));

    private IWebElement PasswordInput => Driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password']"));

    private IWebElement LoginButton => Driver.FindElement(By.CssSelector("div[class*='loginForm__login-button-container']>button"));

    public void SetLoginInputValue(string value)
    {
        LoginInput.Clear();
        LoginInput.SendKeys(value);
    }

    public void SetPasswordInputValue(string value)
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys(value);
    }

    public void ClickLoginButton()
    {
        LoginButton.Click();
    }
}