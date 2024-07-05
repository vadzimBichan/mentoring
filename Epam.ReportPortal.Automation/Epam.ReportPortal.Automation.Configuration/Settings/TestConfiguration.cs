using System.Text.Json;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string Url { get; private init; }
    public string Login { get; private init; }
    public string Password { get; private init; }
    public string BrowserType { get; private init; }

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
            Url = root.GetProperty("TestConfiguration").GetProperty("Url").GetString(),
            Login = root.GetProperty("TestConfiguration").GetProperty("Login").GetString(),
            Password = root.GetProperty("TestConfiguration").GetProperty("Password").GetString(),
            BrowserType = root.GetProperty("TestConfiguration").GetProperty("Browser").GetString()
        };
    }
}