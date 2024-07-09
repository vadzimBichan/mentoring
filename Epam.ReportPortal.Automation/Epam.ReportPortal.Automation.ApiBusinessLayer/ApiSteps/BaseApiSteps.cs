using Epam.ReportPortal.Automation.Configuration.Settings;
using RestSharp;
using Xunit;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps
{
    public abstract class BaseApiSteps
    {
        protected TestConfiguration config;
        protected RestClient client;
        protected string baseUrl;

        public BaseApiSteps()
        {
            config = ConfigurationManager.GetConfiguration();
            baseUrl = $"{config.ApiUrl}/{config.TestProject}"; // "http://localhost:8080/api/v1/default_personal"
            client = new RestClient(baseUrl);
            client.AddDefaultHeader("Authorization", config.ApiToken);
        }
    }
}
