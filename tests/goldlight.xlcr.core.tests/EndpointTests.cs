using System;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
    public class EndpointTests
    {
        [Fact]
        public void GivenInstantiationOfAnEndpoint_WhenTheEndpointIsSet_ThenEndpointIsCreated()
        {
            Endpoint endpoint = new Endpoint("http://www.google.com");
            Assert.Equal(endpoint.Address, "http://www.google.com");
        }

        [Fact]
        public void GivenInstantiationOfEndpoint_WhenTheEndpointIsNull_ThenArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new Endpoint(null));
        }

        [Fact]
        public void GivenInstantiationOfEndpoint_WhenTheEndpointIsHttpWithoutTheColon_ThenArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new Endpoint("httpwww.google.com"));
        }

        [Fact]
        public void GivenInstantiationOfEndpoint_WhenTheEndpointIsHttpsWithoutTheColon_ThenArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new Endpoint("httpswww.google.com"));
        }
        
        [Fact]
        public void GivenInstantiationOfEndpoint_WhenTheEndpointHasLeadingSpaces_ThenTheEndpointIsAccepted()
        {
            Endpoint endpoint = new Endpoint(" HTTPs://www.google.com");
            Assert.Equal(endpoint.Address, " HTTPs://www.google.com");
        }
        [Fact]
        public void GivenInstantiationOfEndpoint_WhenTheEndpointIsCaseInsensitive_ThenTheEndpointIsAccepted()
        {
            Endpoint endpoint = new Endpoint("HTTP://www.google.com");
            Assert.Equal(endpoint.Address, "HTTP://www.google.com");
        }
    }
}