using Epam.ReportPortal.Automation.CoreSelenium.Base;
using OpenQA.Selenium;

namespace Epam.ReportPortal.Automation.CoreSelenium.Elements;

public class TableBase : WebComponent
{
    private static readonly By HeaderLocator = By.CssSelector("div[class*='headerCell__header-cell']");
    private static readonly By RowLocator = By.CssSelector("div[class*='gridRow__grid-row-wrapper']");
    private static readonly By CellLocator = By.CssSelector("[class*='gridCell__grid-cell']");

    public TableBase(IWebDriver driver, By rootLocator) : base(driver, rootLocator)
    {
    }

    public List<IWebElement> GetRows()
    {
        return GetRootElement.FindElements(RowLocator).ToList();
    }

    public int GetRowsCount()
    {
        return GetRows().Count;
    }

    public List<IWebElement> GetHeaders()
    {
        return GetRootElement.FindElements(HeaderLocator).ToList();
    }

    public int GetHeadersCount()
    {
        return GetHeaders().Count;
    }

    public string GetValueFromCell(int rowIndex, int columnIndex)
    {
        var rows = GetRows();
        var cells = rows[rowIndex].FindElements(CellLocator);
        return cells[columnIndex].Text;
    }

    public void ClickHeader(string headerText)
    {
        var headers = GetHeaders();
        foreach (var header in headers)
            if (header.Text.Equals(headerText))
            {
                header.Click();
                break;
            }
    }

    public void ClickCell(int rowIndex, int columnIndex)
    {
        var rows = GetRows();
        var cells = rows[rowIndex].FindElements(CellLocator);
        cells[columnIndex].Click();
    }
}