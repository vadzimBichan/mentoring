using Epam.ReportPortal.Automation.CoreSelenium.Base;
using log4net;
using NUnit.Framework;

namespace Epam.ReportPortal.Automation.UiiBusinessLayer.WebSteps;

public abstract class BasePageSteps<T> where T : BaseWebPage, new()
{
    protected T WebPage { get; } = new();

    protected static readonly ILog Log = LogManager.GetLogger(typeof(T));

    public void ValidatePageTitle(string expectedTitle)
    {
        Assert.That(WebPage.GetTitle(), Is.EqualTo(expectedTitle), "Unexpected page title");
    }

    public void ValidatePageUrl(string expectedUrl)
    {
        Assert.That(WebPage.GetUrl(), Is.EqualTo(expectedUrl), "Unexpected page url");
    }
}