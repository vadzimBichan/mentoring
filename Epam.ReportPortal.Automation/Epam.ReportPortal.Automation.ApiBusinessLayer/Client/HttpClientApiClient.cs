using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.Client;

public class HttpClientApiClient: IApiClient
{
    private readonly HttpClient client;

    public HttpClientApiClient(string baseUrl, string apiToken)
    {
        client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        client.DefaultRequestHeaders.Add("Authorization", apiToken);
    }

    public async Task<HttpResponseMessage> GetAsync(string resource)
    {
        return await client.GetAsync(resource);
    }

    public async Task<HttpResponseMessage> PostAsync(string resource, object body)
    {
        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        return await client.PostAsync(resource, content);
    }

    public async Task<HttpResponseMessage> PutAsync(string resource, object body)
    {
        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        return await client.PutAsync(resource, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string resource)
    {
        return await client.DeleteAsync(resource);
    }
}