using System.Text.Json;

namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string Url { get; private init; }
    public string Login { get; private init; }
    public string Password { get; private init; }
    public string BrowserType { get; private init; }

    public static TestConfiguration GetConfiguration()
    {
        var json = File.ReadAllText("appsettings.json");
        var jsonDoc = JsonDocument.Parse(json);
        var root = jsonDoc.RootElement;

        return new TestConfiguration
        {
            Url = root.GetProperty("TestConfiguration").GetProperty("Url").GetString(),
            Login = root.GetProperty("TestConfiguration").GetProperty("Login").GetString(),
            Password = root.GetProperty("TestConfiguration").GetProperty("Password").GetString(),
            BrowserType = root.GetProperty("TestConfiguration").GetProperty("Browser").GetString()
        };
    }
}