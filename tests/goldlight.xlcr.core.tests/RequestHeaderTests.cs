using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
  public class RequestHeaderTests
  {
    [Fact]
    public void GivenRequestHeader_WhenAddingEmptyKey_ArgumentExceptionIsThrown()
    {
      RequestHeaders requestHeader = new RequestHeaders();
      Assert.Throws<ArgumentException>(() => requestHeader.Add("", ""));
    }

    [Fact]
    public void GivenRequestHeader_WhenAddingEmptyValue_NoArgumentIsThrown()
    {
      RequestHeaders requestHeader = new RequestHeaders();
      Exception e = Record.Exception(() => requestHeader.Add("Header", ""));
      Assert.Null(e);
    }

    [Fact]
    public void GivenRequestHeader_WhenApplyingValues_ValuesAddedToHttpClient()
    {
      HttpClient httpClient = new HttpClient();
      RequestHeaders requestHeader = new RequestHeaders();
      requestHeader.Add("test", "value");
      requestHeader.Apply(httpClient);
      Assert.Equal("value", httpClient.DefaultRequestHeaders.GetValues("test").First());
    }

    [Fact]
    public void GivenRequestHeader_WhenApplyingMultipleValuesToOneKey_ValuesAddedToHttpClient()
    {
      HttpClient httpClient = new HttpClient();
      RequestHeaders requestHeader = new RequestHeaders();
      requestHeader.Add("test", "value");
      requestHeader.Add("test", "value2");
      requestHeader.Apply(httpClient);
      var headers = httpClient.DefaultRequestHeaders.GetValues("test");
      Assert.Collection(headers, item => Assert.Equal("value", item), item => Assert.Equal("value2", item));
    }


    [Fact]
    public void GivenRequestHeader_WhenCallingApplyMoreThanOnce_ThenOnlyOneValueIsPresent()
    {
      HttpClient httpClient = new HttpClient();
      RequestHeaders requestHeader = new RequestHeaders();
      requestHeader.Add("test", "value");
      requestHeader.Apply(httpClient);
      requestHeader.Apply(httpClient);
      IEnumerable<string> headers = httpClient.DefaultRequestHeaders.GetValues("test");
      Assert.Single(headers);
    }

    [Fact]
    public void GivenRequestHeader_WhenDuplicatingValue_ThenThisIsAllowed()
    {
      HttpClient httpClient = new HttpClient();
      RequestHeaders requestHeader = new RequestHeaders();
      requestHeader.Add("test", "value");
      requestHeader.Add("test", "value");
      requestHeader.Apply(httpClient);
      var headers = httpClient.DefaultRequestHeaders.GetValues("test");
      Assert.Collection(headers, item => Assert.Equal("value", item), item => Assert.Equal("value", item));
    }

    [Fact]
    public void GivenRequestHeader_WhenDuplicatingEmptyStringValue_ThenThisIsAllowed()
    {
      HttpClient httpClient = new HttpClient();
      RequestHeaders requestHeader = new RequestHeaders();
      requestHeader.Add("test", "");
      requestHeader.Add("test", "");
      requestHeader.Apply(httpClient);
      var headers = httpClient.DefaultRequestHeaders.GetValues("test");
      Assert.Collection(headers, item => Assert.Equal("", item), item => Assert.Equal("", item));
    }
  }
}
