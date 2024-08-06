using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class EditModalBase : ModalBase
{
    private IWebElement UpdateButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-booger']"));

    private IWebElement CancelButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-gray-60']"));

    public EditModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickUpdate()
    {
        UpdateButton.Click();
        // wait: consider a case that click does not close the modal (negative cases - empty mandatory fields)
    }

    public void ClickCancel()
    {
        CancelButton.Click();
        WaitElementInvisibility();
    }
}