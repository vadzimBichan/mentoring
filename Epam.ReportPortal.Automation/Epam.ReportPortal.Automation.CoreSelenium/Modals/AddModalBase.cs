using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class AddModalBase : ModalBase
{
    public IWebElement AddButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-booger']"));

    public IWebElement CancelButton => GetRootElement.FindElement(By.CssSelector("div[class^='modalFooter'] button[class*='bigButton__color-gray-60']"));

    public AddModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void ClickAdd()
    {
        AddButton.Click();
        // wait: consider a case that click does not close the modal (empty fields)
    }

    public void ClickCancel()
    {
        CancelButton.Click();
        WaitElementInvisibility();
    }
}