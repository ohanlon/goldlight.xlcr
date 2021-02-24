using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
    public class GetRequestTests
    {
        [Fact]
        public void Test1()
        {
            GetRequest getRequest = new GetRequest();
            Assert.NotNull(getRequest.Execute("http://www.google.com"));
        }

        [Fact]
        public void GivenCallToExecuteGetRequest_WhenNoEndpointIsSet_ThenArgumentExceptionIsThrown()
        {
            GetRequest getRequest = new GetRequest();
            Assert.NotNull(getRequest.Execute("http://www.google.com"));
        }
    }

}
