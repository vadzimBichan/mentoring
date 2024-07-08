using Microsoft.Extensions.Configuration;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string Url { get; private init; }
    public string Login { get; private init; }
    public string Password { get; private init; }
    public string BrowserType { get; private init; }

    private static readonly IConfiguration config;

    static TestConfiguration()
    {
        config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<TestConfiguration>()
            .Build();
    }

    public static TestConfiguration GetConfiguration()
    {
        IConfigurationSection sutSettings = config.GetSection("TestConfiguration");

        return new TestConfiguration
        {
            Url = sutSettings["Url"],
            Login = sutSettings["Login"],
            Password = sutSettings["Password"],
            BrowserType = sutSettings["Browser"]
        };
    }
}