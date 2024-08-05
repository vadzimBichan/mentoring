using Epam.ReportPortal.Automation.CoreSelenium.Base;
using log4net;
using NUnit.Framework;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps;

public abstract class BasePageSteps<T> where T : WebPage, new()
{
    protected T Page { get; } = new();

    protected static readonly ILog Log = LogManager.GetLogger(typeof(T));

    public void ValidatePageTitle(string expectedTitle)
    {
        Assert.That(Page.GetTitle(), Is.EqualTo(expectedTitle), "Unexpected page title");
    }

    public void ValidatePageUrl(string expectedUrl)
    {
        Assert.That(Page.GetUrl(), Is.EqualTo(expectedUrl), "Unexpected page url");
    }
}