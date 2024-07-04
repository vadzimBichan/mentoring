namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components
{
    public class LeftPanelComponent : BaseWebComponent
    {
        public override IWebElement Root => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement DashboardsItem => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement LaunchesItem => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement FiltersItem => Browser.Driver.FindElement(By.CssSelector("TODO"));


        public IWebElement ProjectSettingsItem => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement UserIcon => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public LeftPanelComponent(Browser browser) : base(browser)
        {
        }
    }
}
