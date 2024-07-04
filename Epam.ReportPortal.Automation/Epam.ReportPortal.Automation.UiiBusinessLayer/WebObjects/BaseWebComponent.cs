namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects
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
