namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebObjects.Components
{
    public class FooterComponent : BaseWebComponent
    {
        public override IWebElement Root => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement ApplicationVersionLabel => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement GitHubLink => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement SlackLink => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement ContactUsLink => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement DocumentationLink => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public IWebElement PolicyLink => Browser.Driver.FindElement(By.CssSelector("TODO"));

        public FooterComponent(Browser browser) : base(browser)
        {
        }
    }
}
