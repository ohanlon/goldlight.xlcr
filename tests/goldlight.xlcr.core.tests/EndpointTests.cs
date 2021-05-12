using System;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
  public class EndpointTests
  {
    [Fact]
    public void GivenEmptyQueryString_WhenTransformCalled_ThenEndpointIsUnchanged()
    {
      Endpoint endpoint = new Endpoint("http://www.google.com", new QueryString());
      Assert.Equal("http://www.google.com", endpoint.Address);
    }

    [Fact]
    public void GivenKeyValuePairQueryString_WhenTransformCalled_ThenEndpointIsChanged()
    {
      QueryString queryString = new QueryString();
      queryString.Add("id", "1");
      Endpoint endpoint = new Endpoint("http://www.google.com/{id}", queryString);
      Assert.Equal("http://www.google.com/1", endpoint.Address);
    }

    [Fact]
    public void GivenInstantiationOfAnEndpoint_WhenTheEndpointIsSet_ThenEndpointIsCreated()
    {
      Endpoint endpoint = new Endpoint("http://www.google.com", null);
      Assert.Equal("http://www.google.com", endpoint.Address);
    }

    [Fact]
    public void GivenInstantiationOfEndpoint_WhenTheEndpointIsNull_ThenArgumentExceptionIsThrown()
    {
      Assert.Throws<ArgumentException>(() => new Endpoint(null, null));
    }

    [Fact]
    public void GivenInstantiationOfEndpoint_WhenTheEndpointIsHttpWithoutTheColon_ThenArgumentExceptionIsThrown()
    {
      Assert.Throws<ArgumentException>(() => new Endpoint("httpwww.google.com", null));
    }

    [Fact]
    public void GivenInstantiationOfEndpoint_WhenTheEndpointIsHttpsWithoutTheColon_ThenArgumentExceptionIsThrown()
    {
      Assert.Throws<ArgumentException>(() => new Endpoint("httpswww.google.com", null));
    }

    [Fact]
    public void GivenInstantiationOfEndpoint_WhenTheEndpointHasLeadingSpaces_ThenTheEndpointIsAccepted()
    {
      Endpoint endpoint = new Endpoint(" HTTPs://www.google.com", null);
      Assert.Equal(" HTTPs://www.google.com", endpoint.Address);
    }
    [Fact]
    public void GivenInstantiationOfEndpoint_WhenTheEndpointIsCaseInsensitive_ThenTheEndpointIsAccepted()
    {
      Endpoint endpoint = new Endpoint("HTTP://www.google.com", null);
      Assert.Equal("HTTP://www.google.com", endpoint.Address);
    }
  }
}