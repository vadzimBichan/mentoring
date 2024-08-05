using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Modals;

public class ModalBase : WebComponent
{
    private IWebElement HeaderLabel => GetRootElement.FindElement(By.CssSelector("span[class*='modal-title']"));

    private IWebElement CrossButton => GetRootElement.FindElement(By.CssSelector("div[class*='close-modal-icon']>svg"));

    public ModalBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public void CLickClose()
    {
        CrossButton.Click();
        WaitElementInvisibility();
    }

    public string GetModalHeader()
    {
        return HeaderLabel.Text;
    }

    public bool IsDialogVisible()
    {
        try
        {
            return  HeaderLabel.Displayed; // test via header
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }
}