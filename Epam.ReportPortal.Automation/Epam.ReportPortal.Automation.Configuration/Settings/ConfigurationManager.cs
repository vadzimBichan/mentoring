using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class ConfigurationManager
{
    private static readonly TestConfiguration _config;
    private static readonly IConfigurationRoot _configuration;

    static ConfigurationManager()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly()) // C:\Users\<username>\AppData\Roaming\Microsoft\UserSecrets\<UserSecretsId>\secrets.json.
            .Build();
        _config = _configuration.Get<TestConfiguration>();
    }

    public static TestConfiguration GetConfiguration()
    {
        return _config;
    }
}