using Epam.ReportPortal.Automation.ApiModels.CommonModels;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps;

public abstract class BaseApiSteps
{
    public string GetMessageFromResponse(HttpResponseMessage response)
    {
        var contentString = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<MessageModel>(contentString).Value;
    }

    public ErrorMessageModel GetErrorFromResponse(HttpResponseMessage response)
    {
        var contentString = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<ErrorMessageModel>(contentString);
    }

    public void VerifyResponseCode(HttpResponseMessage response, HttpStatusCode expectedStatusCode)
    {
        response.StatusCode.Should().Be(expectedStatusCode);
    }
}