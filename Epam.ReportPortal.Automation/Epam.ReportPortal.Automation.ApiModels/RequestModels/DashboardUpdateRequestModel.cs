using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.RequestModels;

public class DashboardUpdateRequestModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("updateWidgets")]
    public List<WidgetModel> Widgets { get; set; }
}