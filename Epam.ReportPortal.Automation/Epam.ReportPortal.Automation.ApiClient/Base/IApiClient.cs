namespace Epam.ReportPortal.Automation.ApiClient.Base;

public interface IApiClient
{
    Task<HttpResponseMessage> GetAsync(string resource);
    Task<HttpResponseMessage> PostAsync(string resource, object body);
    Task<HttpResponseMessage> PutAsync(string resource, object body);
    Task<HttpResponseMessage> DeleteAsync(string resource);
}