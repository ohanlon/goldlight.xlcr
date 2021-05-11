using System;

namespace Goldlight.Xlcr.Core
{
  public class Endpoint
  {
    public Endpoint(string endpoint, QueryString queryString)
    {
      if (queryString != null)
      {
        endpoint = queryString.Transform(endpoint);
      }
      if (!IsHttpFormatEndpoint(endpoint))
      {
        throw new ArgumentException(null, nameof(endpoint));
      }

      Address = endpoint;
    }
    public string Address { get; }

    private bool IsHttpFormatEndpoint(string endpoint) => Uri.TryCreate(endpoint, UriKind.Absolute, out Uri uri)
            && uri.IsWellFormedOriginalString()
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
  }
}