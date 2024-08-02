using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.RequestModels;

public class DashboardCreateRequestModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
}