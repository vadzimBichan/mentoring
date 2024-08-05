using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class DeleteModalBase : ModalBase
{
    private IWebElement DeleteButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Delete')]"));

    private IWebElement CancelButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));

    public DeleteModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickDelete(bool shouldModalCloses = true)
    {
        DeleteButton.Click();
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