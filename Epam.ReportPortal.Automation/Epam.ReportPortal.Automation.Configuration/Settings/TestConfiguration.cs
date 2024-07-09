namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string WebUrl { get; set; }
    public string BrowserType { get; set; }
    public string TestUserLogin { get; set; }
    public string TestUserPassword { get; set; }
    public string TestProject { get; set; }

    public string ApiUrl { get; private init; }
    public string ApiToken { get; private init; }
}
