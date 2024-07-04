using Epam.ReportPortal.Automation.Core.Selenium;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.BusinessLayer.UiObjects
{
    public abstract class BaseWebComponent
    {
        public abstract IWebElement Root { get; }

        protected Browser Browser;

        protected BaseWebComponent (Browser browser)
        {
            Browser = browser;
        }
    }
}
