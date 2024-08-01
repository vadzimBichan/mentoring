using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class PageModel
{
    [JsonProperty("number")] 
    public int Number { get; set; }
    [JsonProperty("size")] 
    public int Size { get; set; }
    [JsonProperty("totalElements")] 
    public int TotalElements { get; set; }
    [JsonProperty("totalPages")] 
    public int TotalPages { get; set; }
}