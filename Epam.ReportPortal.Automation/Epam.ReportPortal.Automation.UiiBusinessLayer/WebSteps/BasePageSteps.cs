using Epam.ReportPortal.Automation.Configuration.Settings;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps
{
    public abstract class BasePageSteps
    {
        public readonly TestConfiguration Config;

        protected BasePageSteps(TestConfiguration config)
        {
            Config = config;
        }

        public void ValidatePageTitle(string expectedTitle)
        {
            // Assert.That(Browser.GetTitle(), Is.EqualTo(expectedTitle), "Unexpected page title");
        }

        public void ValidatePageUrl(string expectedUrl)
        {
            // Assert.That(Browser.GetUrl(), Is.EqualTo(expectedUrl), "Unexpected page url");
        }

        // TODO: add browser steps
    }
}
