using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class WidgetOptionsModel
{
    [JsonProperty("zoom")] 
    public bool Zoom { get; set; }
    [JsonProperty("timeline")] 
    public string Timeline { get; set; }
    [JsonProperty("viewMode")] 
    public string ViewMode { get; set; }
}