using System.Net;
using Epam.ReportPortal.Automation.ApiBusinessLayer.Client;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Xunit;
using ConfigurationManager = Epam.ReportPortal.Automation.Configuration.Settings.ConfigurationManager;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;

public abstract class BaseApiSteps
{
    protected TestConfiguration config;
    protected IApiClient client;
    protected string baseUrl;

    protected BaseApiSteps()
    {
        config = ConfigurationManager.GetConfiguration();

        switch (config.ClientType)
        {
            case "RestSharp":
                client = new RestSharpApiClient(config.ApiUrl, config.ApiToken);
                break;
            case "HttpClient":
                client = new HttpClientApiClient(config.ApiUrl, config.ApiToken);
                break;
            default:
                throw new Exception("The client is not supported");
        }
    }

    public void VerifyResponseCode(HttpResponseMessage response, HttpStatusCode expectedStatusCode)
    {
        Assert.Equal(expectedStatusCode, response.StatusCode);
    }
}