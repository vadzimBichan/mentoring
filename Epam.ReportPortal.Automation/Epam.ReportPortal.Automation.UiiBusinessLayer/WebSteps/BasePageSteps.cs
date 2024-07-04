namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps
{
    public abstract class BasePageSteps
    {
        protected Browser Browser;


        protected BasePageSteps(Browser browser)
        {
            Browser = browser;
        }

        public void ValidatePageTitle(string expectedTitle)
        {
            Assert.That(Browser.GetTitle(), Is.EqualTo(expectedTitle), "Unexpected page title");
        }

        public void ValidatePageUrl(string expectedUrl)
        {
            Assert.That(Browser.GetUrl(), Is.EqualTo(expectedUrl), "Unexpected page url");
        }
    }
}
