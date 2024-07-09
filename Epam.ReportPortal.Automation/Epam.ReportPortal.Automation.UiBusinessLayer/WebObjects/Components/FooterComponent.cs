using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebObjects.Components;

public class FooterComponent : BaseWebComponent
{
    public FooterComponent(string testName) : base(testName)
    {    }

    public override IWebElement Root => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement ApplicationVersionLabel => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement GitHubLink => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement SlackLink => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement ContactUsLink => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement DocumentationLink => Driver.FindElement(By.CssSelector("TODO"));

    public IWebElement PolicyLink => Driver.FindElement(By.CssSelector("TODO"));
}