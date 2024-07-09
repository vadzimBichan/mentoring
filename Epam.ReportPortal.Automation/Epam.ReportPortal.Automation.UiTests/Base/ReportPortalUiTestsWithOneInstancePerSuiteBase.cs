﻿using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Dashboards;

namespace Epam.ReportPortal.Automation.UiTests.Base;

[TestFixture]
public abstract class ReportPortalUiTestsWithOneInstancePerSuiteBase
{
    protected Browser Browser;
    protected TestConfiguration TestConfiguration;
    protected LoginPageSteps LoginPageSteps => new();

    [OneTimeSetUp]
    public void BeforeAll()
    {
        TestConfiguration = ConfigurationManager.GetConfiguration();
        LogConfiguration.Setup();
        Browser = Browser.GetInstance;
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        Browser.Close();
    }
}