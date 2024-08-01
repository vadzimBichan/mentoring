using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.CommonModels;

public class ErrorMessageModel
{
    [JsonProperty("errorCode")] 
    public int ErrorCode { get; set; }
    [JsonProperty("message")] 
    public string Value { get; set; }
}