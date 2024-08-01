using System.Text;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiClient.Base;

public class HttpClientApiClient : IApiClient
{
    private readonly HttpClient _client;

    public HttpClientApiClient(string baseUrl, string apiToken)
    {
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _client.DefaultRequestHeaders.Add("Authorization", apiToken);
    }

    public async Task<HttpResponseMessage> GetAsync(string resource)
    {
        return await _client.GetAsync(resource);
    }

    public async Task<HttpResponseMessage> PostAsync(string resource, object body)
    {
        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        return await _client.PostAsync(resource, content);
    }

    public async Task<HttpResponseMessage> PutAsync(string resource, object body)
    {
        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        return await _client.PutAsync(resource, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string resource)
    {
        return await _client.DeleteAsync(resource);
    }
}