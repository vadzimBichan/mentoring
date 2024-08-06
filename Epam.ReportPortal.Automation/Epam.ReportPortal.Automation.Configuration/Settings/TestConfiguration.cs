﻿namespace Epam.ReportPortal.Automation.Configuration.Settings;

public class TestConfiguration
{
    public string WebUrl { get; set; }
    public string BrowserType { get; set; }
    public string TestUserLogin { get; set; }
    public string TestUserPassword { get; set; }
    public string TestProject { get; set; }

    public string ApiUrl { get; set; }
    public string ApiToken { get; set; }
    public string ClientType { get; set; }

    public bool UseGrid { get; set; }
    public string GridUrl { get; set; }
}
