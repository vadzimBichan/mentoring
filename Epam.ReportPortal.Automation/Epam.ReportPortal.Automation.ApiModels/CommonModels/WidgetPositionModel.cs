using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class WidgetPositionModel
{
    [JsonProperty("positionX")] 
    public int PositionX { get; set; }
    [JsonProperty("positionY")] 
    public int PositionY { get; set; }
}