using RestSharp;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.Client;

public class RestSharpApiClient : IApiClient
{
    private readonly RestClient client;

    public RestSharpApiClient(string baseUrl, string apiToken)
    {
        client = new RestClient(baseUrl);
        client.AddDefaultHeader("Authorization", apiToken);
    }

    public async Task<HttpResponseMessage> GetAsync(string resource)
    {
        var request = new RestRequest(resource);
        var response = await client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> PostAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Post);
        request.AddJsonBody(body);
        var response = await client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> PutAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Put);
        request.AddJsonBody(body);
        var response = await client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> DeleteAsync(string resource)
    {
        var request = new RestRequest(resource, Method.Delete);
        var response = await client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }
}