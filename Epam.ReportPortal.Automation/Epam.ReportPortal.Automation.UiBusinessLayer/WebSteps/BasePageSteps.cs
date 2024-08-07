using Epam.ReportPortal.Automation.CoreSelenium.Base;
using FluentAssertions;
using log4net;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps;

public abstract class BasePageSteps<T> where T : WebPage, new()
{
    protected Browser Browser => Browser.GetInstance();

    protected T Page { get; } = new();

    protected static readonly ILog Log = LogManager.GetLogger(typeof(T));

    public void ValidatePageTitle(string expectedTitle)
    {
        Page.GetTitle().Should().Be(expectedTitle);
    }

    public void ValidatePageUrl(string expectedUrl)
    {
        Page.GetUrl().Should().Be(expectedUrl);
    }
}