using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class MessageModel
{
    [JsonProperty("message")] 
    public string Value { get; set; }
}