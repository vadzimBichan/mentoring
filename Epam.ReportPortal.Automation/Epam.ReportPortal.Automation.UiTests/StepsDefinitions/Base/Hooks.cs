using Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;
using Epam.ReportPortal.Automation.Configuration.Logger;
using Epam.ReportPortal.Automation.Configuration.Settings;
using Epam.ReportPortal.Automation.CoreSelenium.Base;
using System.Net;

namespace Epam.ReportPortal.Automation.UiTests.StepsDefinitions.Base;

[Binding]
// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
public sealed class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;

    public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [BeforeTestRun]
    public static void BeforeTestsRun()
    {
        ConfigurationManager.GetConfiguration();
        LogConfiguration.Setup();
    }

    [AfterTestRun]
    public static void AfterTestsRun()
    {
        // not used at the moment
    }

    [BeforeFeature]
    public static void BeforeEachFeature()
    {
        // TODO: Add project creation via admin to have own project per feature file
        // And put its id in feature context to use later (for example to clean)
        // Use API steps for more robust solution
    }

    [AfterFeature]
    public static void AfterEachFeature()
    {
        // TODO: Clean projects via admin
        // Use API steps for more robust solution
    }

    [BeforeScenario]
    public void BeforeEachScenario()
    {
        _scenarioContext["DashboardIDs"] = new List<int>();
        Browser.GetInstance();
    }

    [AfterScenario]
    public void AfterEachScenario()
    {
        try
        {
            var dashboardIds = _scenarioContext.Get<List<int>>("DashboardIDs");
            var dashboardsApiSteps = new DashboardApiSteps();
            foreach (var dashboardId in dashboardIds)
            {
                var response = dashboardsApiSteps.DeleteDashboardRequest(dashboardId);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    $"Issues with removing dashboard with id = '{dashboardId}'!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _scenarioContext["DashboardIDs"] = null;
            Browser.Close();
        }
    }
}