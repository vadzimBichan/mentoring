using Epam.ReportPortal.Automation.ApiClient.Base;
using Epam.ReportPortal.Automation.Configuration.Settings;

namespace Epam.ReportPortal.Automation.ApiClient.Clients;

public class BaseClient
{
    protected TestConfiguration Config;
    protected IApiClient Client;

    protected BaseClient()
    {
        Config = ConfigurationManager.GetConfiguration();

        switch (Config.ClientType)
        {
            case "RestSharp":
                Client = new RestSharpApiClient(Config.ApiUrl, Config.ApiToken);
                break;
            case "HttpClient":
                Client = new HttpClientApiClient(Config.ApiUrl, Config.ApiToken);
                break;
            default:
                throw new Exception("The client is not supported");
        }
    }
}