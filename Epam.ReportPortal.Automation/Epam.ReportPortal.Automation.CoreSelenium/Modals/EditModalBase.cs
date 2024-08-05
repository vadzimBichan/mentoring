using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class EditModalBase : ModalBase
{
    private IWebElement UpdateButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Update')]"));

    private IWebElement CancelButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));

    public EditModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickUpdate(bool shouldModalCloses = true)
    {
        UpdateButton.Click();
        if (shouldModalCloses)
        {
            WaitElementInvisibility();
        }
        else
        {
            WaitElementVisibility();
        }
    }

    public void ClickCancel()
    {
        CancelButton.Click();
        WaitElementInvisibility();
    }
}