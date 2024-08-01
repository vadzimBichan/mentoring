using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class DashboardModel
{
    [JsonProperty("name")] 
    public string Name { get; set; }
    [JsonProperty("description")] 
    public string Description { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("owner")] 
    public string Owner { get; set; }
    [JsonProperty("widgets")] 
    public List<WidgetModel> Widgets { get; set; }
}