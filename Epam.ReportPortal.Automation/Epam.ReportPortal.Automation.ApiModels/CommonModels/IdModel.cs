using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class IdModel
{
    [JsonProperty("id")] 
    public int Value { get; set; }
}