using Epam.ReportPortal.Automation.BusinessLayer.UiObjects.Components;
using Epam.ReportPortal.Automation.Core.Selenium;

namespace Epam.ReportPortal.Automation.BusinessLayer.UiObjects
{
    public abstract class BaseWebPage
    {
        protected readonly Browser Browser;

        protected BaseWebPage(Browser browser)
        {
            Browser = browser;
        }
    }
}
