using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class WidgetSizeModel
{
    [JsonProperty("width")] 
    public int Width { get; set; }
    [JsonProperty("height")] 
    public int Height { get; set; }
}