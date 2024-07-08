using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class ConfigurationManager
{
    private static readonly TestConfiguration _config;
    private static readonly IConfigurationRoot _configuration;
    static ConfigurationManager()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
        _config = _configuration.GetSection("TestConfiguration").Get<TestConfiguration>();
    }

    public static TestConfiguration GetConfiguration()
    {
        return _config;
    }
}