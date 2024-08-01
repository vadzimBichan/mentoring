using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiModels.ResponseModels;

public class DashboardGetAllResponseModels
{
    [JsonProperty("content")] 
    public List<DashboardModel> Dashboards { get; set; }
    [JsonProperty("page")] 
    public PageModel Page { get; set; }
}