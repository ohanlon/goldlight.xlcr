using Goldlight.HttpClientTestSupport;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
  public class GetRequestTests
  {
    [Fact]
    public async Task GivenHeader_WhenCallingExecuteGetRequest_HeaderIsSetInRequestMessage()
    {
      string timestamp = DateTime.UtcNow.ToString();
      FakeHttpMessageHandler fakeHttpMessageHandler = new FakeHttpMessageHandler();
      RequestHeaders requestHeaders = new RequestHeaders();
      requestHeaders.Add("timestamp", timestamp);
      HttpClient httpClient = new HttpClient(fakeHttpMessageHandler);
      GetRequest getRequest = new GetRequest(httpClient)
      {
        RequestHeaders = requestHeaders
      };
      HttpResponseMessage response = await getRequest.Execute("http://www.google.com");
      Assert.Equal(timestamp, response.RequestMessage.Headers.GetValues("timestamp").First());
    }

    [Fact]
    public async Task GivenCallToExecuteGetRequest_WhenEndpointIsSet_ThenNonNullResponseIsReturned()
    {
      FakeHttpMessageHandler fakeHttpMessageHandler = new FakeHttpMessageHandler();
      HttpClient httpClient = new HttpClient(fakeHttpMessageHandler);
      GetRequest getRequest = new GetRequest(httpClient);
      Assert.NotNull(await getRequest.Execute("http://www.google.com"));
    }

    [Fact]
    public async Task GivenCallToExecuteGetRequest_WhenNoEndpointIsSet_ThenArgumentExceptionIsThrown()
    {
      FakeHttpMessageHandler fakeHttpMessageHandler = new FakeHttpMessageHandler();
      HttpClient httpClient = new HttpClient(fakeHttpMessageHandler);
      GetRequest getRequest = new GetRequest(httpClient);
      await Assert.ThrowsAsync<ArgumentException>(() => getRequest.Execute(""));
    }

    [Fact]
    public void GivenCallToQueryString_WhenSettingValue_ThenQueryStringIsSet()
    {
      FakeHttpMessageHandler fakeHttpMessageHandler = new FakeHttpMessageHandler();
      HttpClient httpClient = new HttpClient(fakeHttpMessageHandler);
      QueryString queryString = new QueryString();
      GetRequest getRequest = new GetRequest(httpClient)
      {
        QueryString = queryString
      };
      Assert.Equal(queryString, getRequest.QueryString);
    }

    [Fact]
    public void GivenInstantiation_WithNullHttpClient_ThenArgumentNullExceptionIsThrown()
    {
      HttpClient client = null;
      Assert.Throws<ArgumentNullException>(() => new GetRequest(client));
    }
  }
}
