using RestSharp;

namespace Epam.ReportPortal.Automation.ApiClient.Base;

public class RestSharpApiClient : IApiClient
{
    private readonly RestClient _client;

    public RestSharpApiClient(string baseUrl, string apiToken)
    {
        _client = new RestClient(baseUrl);
        _client.AddDefaultHeader("Authorization", apiToken);
    }

    public async Task<HttpResponseMessage> GetAsync(string resource)
    {
        var request = new RestRequest(resource);
        var response = await _client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> PostAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Post);
        request.AddJsonBody(body);
        var response = await _client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> PutAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Put);
        request.AddJsonBody(body);
        var response = await _client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }

    public async Task<HttpResponseMessage> DeleteAsync(string resource)
    {
        var request = new RestRequest(resource, Method.Delete);
        var response = await _client.ExecuteAsync(request);
        return new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.Content) };
    }
}