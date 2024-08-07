using Epam.ReportPortal.Automation.CoreSelenium.Modals;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Modals;

public class EditDashboardDialog : EditModalBase
{
    private IWebElement NameInput => GetRootElement.FindElement(By.CssSelector("input[type='text'][placeholder='Enter dashboard name']"));

    private IWebElement DescriptionInput => GetRootElement.FindElement(By.CssSelector("textarea[placeholder='Enter dashboard description']"));

    public EditDashboardDialog(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    #region NameInput

    public string GetNameInputValue()
    {
        return NameInput.Text;
    }

    public void ClearNameInput()
    {
        NameInput.Clear();
    }

    public void SetNameInputValue(string value)
    {
        NameInput.Clear();
        NameInput.SendKeys(value);
    }

    public void AppendNameInputValue(string value)
    {
        NameInput.SendKeys(value);
    }

    #endregion

    #region DescriptionInput

    public string GetDescriptionInputValue()
    {
        return DescriptionInput.Text;
    }

    public void ClearDescriptionInput()
    {
        DescriptionInput.Clear();
    }

    public void SetDescriptionInputValue(string value)
    {
        DescriptionInput.Clear();
        DescriptionInput.SendKeys(value);
    }

    public void AppendDescriptionInputValue(string value)
    {
        DescriptionInput.SendKeys(value);
    }

    #endregion
}