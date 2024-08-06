using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class DeleteModalBase : ModalBase
{
    private IWebElement DeleteButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-booger']"));

    private IWebElement CancelButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-gray-60']"));

    public DeleteModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickDelete()
    {
        DeleteButton.Click();
        // wait: consider a case that click does not close the modal (e.g. permissions)
    }

    public void ClickCancel()
    {
        CancelButton.Click();
        WaitElementInvisibility();
    }
}