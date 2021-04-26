using System;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
    public class GetRequestTests
    {

        [Fact]
        public void GivenCallToExecuteGetRequest_WhenNoEndpointIsSet_ThenNonNullResponseIsReturned()
        {
            GetRequest getRequest = new GetRequest();
            Assert.NotNull(getRequest.Execute("http://www.google.com"));
        }

        [Fact]
        public void GivenCallToExecuteGetRequest_WhenNoEndpointIsSet_ThenArgumentExceptionIsThrown()
        {
            GetRequest getRequest = new GetRequest();
            Assert.Throws<ArgumentException>(() => getRequest.Execute(""));
        }
    }

}
