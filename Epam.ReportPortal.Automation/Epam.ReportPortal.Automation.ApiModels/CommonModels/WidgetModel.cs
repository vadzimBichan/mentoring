using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class WidgetModel
{
    [JsonProperty("widgetName")] 
    public string Name { get; set; }
    [JsonProperty("widgetType")] 
    public string Type { get; set; }
    [JsonProperty("widgetId")] 
    public int Id { get; set; }
    [JsonProperty("widgetSize")] 
    public WidgetSizeModel Size { get; set; }
    [JsonProperty("widgetPosition")] 
    public WidgetPositionModel Position { get; set; }
    [JsonProperty("widgetOptions")] 
    public WidgetOptionsModel Options { get; set; }
}