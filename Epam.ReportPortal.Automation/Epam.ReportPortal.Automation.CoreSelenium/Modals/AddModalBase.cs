using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class AddModalBase : ModalBase
{
    public IWebElement AddButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Add')]"));

    public IWebElement CancelButton => GetRootElement.FindElement(By.XPath("//button[contains(text(), 'Cancel')]"));

    public AddModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickAdd(bool shouldModalCloses = true)
    {
        AddButton.Click();
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