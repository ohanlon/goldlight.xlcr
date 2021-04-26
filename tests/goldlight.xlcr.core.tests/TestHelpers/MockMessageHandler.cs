using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Goldlight.Xlcr.Core.Tests.TestHelpers
{
    /// <summary>
    /// The MockMessageHandler implementation helps us set up a mock message handler that
    /// we can pass in to an HttpClient. By supplying this implementation, we can set up
    /// expectations on a unit test using FakeItEasy.
    /// </summary>
    /// <example>
    /// <code>
    /// MockMessageHandler fake = A.Fake&lt;MockMessageHandler&gt;();
    /// A.CallTo(() =$gt; fake.DoSendAsync(A&lt;HttpRequestMessage&gt;,_))
    ///     .Returns(new HttpResponseMessage(HttpStatusCode.Success));
    /// HttpClient client = new HttpClient(fake);
    /// </code>
    /// </example>
    public abstract class MockMessageHandler : HttpMessageHandler
    {
        protected override sealed Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return DoSendAsync(request);
        }

        public abstract Task<HttpResponseMessage> DoSendAsync(HttpRequestMessage request);
    }
}
