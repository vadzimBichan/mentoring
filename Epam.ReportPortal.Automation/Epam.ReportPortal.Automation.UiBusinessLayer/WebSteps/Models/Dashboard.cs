namespace Epam.ReportPortal.Automation.UiBusinessLayer.WebSteps.Models;

public class Dashboard
{
    public string Name { get; }
    public string Description { get; }
    public string Owner { get; }

    public Dashboard(string name, string description, string owner)
    {
        Name = name;
        Description = description;
        Owner = owner;
    }
}