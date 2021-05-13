using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Goldlight.Xlcr.Core
{
  public abstract class Request
  {
    public Request(HttpClient client)
    {
      Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<HttpResponseMessage> Execute(string endpoint)
    {
      RequestHeaders?.Apply(Client);
      return Execute(new Endpoint(endpoint, QueryString));
    }

    public QueryString QueryString { get; set; }

    public RequestHeaders RequestHeaders { get; set; }

    protected HttpClient Client { get; }

    protected abstract Task<HttpResponseMessage> Execute(Endpoint endpoint);
  }
}