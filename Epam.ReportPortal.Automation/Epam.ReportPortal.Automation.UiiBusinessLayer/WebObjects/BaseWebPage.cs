namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects
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
