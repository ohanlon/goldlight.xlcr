using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Goldlight.Xlcr.Core
{
  public class GetRequest : Request
  {
    public GetRequest(HttpClient client) : base(client) { }

    protected async override Task<HttpResponseMessage> Execute(Endpoint endpoint) => await Client.GetAsync(endpoint.Address);
  }
}