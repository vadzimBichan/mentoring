using System.Text.Json;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string WebUrl { get; private init; }
    public string BrowserType { get; private init; }
    public string TestUserLogin { get; private init; }
    public string TestUserPassword { get; private init; }
    public string TestProject { get; private init; }

    public string ApiUrl { get; private init; }
    public string ApiToken { get; private init; }

    private static readonly JsonDocument settingsJson;

    static TestConfiguration()
    {
        var json = File.ReadAllText("appsettings.json");
        settingsJson = JsonDocument.Parse(json);
    }

    public static TestConfiguration GetConfiguration()
    {
        var root = settingsJson.RootElement;

        return new TestConfiguration
        {
            // Url = root.GetProperty("TestConfiguration").GetProperty("Url").GetString(),
            //Login = root.GetProperty("TestConfiguration").GetProperty("Login").GetString(),
            //Password = root.GetProperty("TestConfiguration").GetProperty("Password").GetString(),
            BrowserType = root.GetProperty("TestConfiguration").GetProperty("Browser").GetString()
        };
    }
}