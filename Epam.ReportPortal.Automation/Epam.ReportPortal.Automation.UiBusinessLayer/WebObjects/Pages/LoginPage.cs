using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Pages;

public class LoginPage : WebPage
{
    #region Main Flow

    private IWebElement LoginInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Login']"));

    private IWebElement PasswordInput => Driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password']"));

    private IWebElement LoginButton => Driver.FindElement(By.CssSelector("div[class*='loginForm__login-button-container'] > button"));

    private IWebElement ForgotPasswordLink => Driver.FindElement(By.CssSelector("a[class*='loginForm__forgot-pass']"));

    #endregion

    #region Forgot Password

    private IWebElement EmailInput => Driver.FindElement(By.CssSelector("input[type='text'][placeholder='Enter email']"));

    private IWebElement CancelButton => Driver.FindElement(By.CssSelector("div[class*='forgotPasswordForm__forgot-password-buttons-container'] button[type='button']"));

    private IWebElement SendEmailButton => Driver.FindElement(By.CssSelector("div[class*='forgotPasswordForm__forgot-password-buttons-container'] button[type='submit']"));

    #endregion

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
        // TODO: ONLY AS EXAMPLE
        // LoginButton.Click();
        ClickViaJs(LoginButton);
    }

    public void ClickForgotPasswordLink()
    {
        ForgotPasswordLink.Click();
    }
}