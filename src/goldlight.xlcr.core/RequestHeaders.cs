using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Goldlight.Xlcr.Core
{
  public class RequestHeaders
  {
    private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>();

    public void Add(string key, string value)
    {
      if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("You must supply the header name.");
      if (!_headers.ContainsKey(key))
      {
        _headers[key] = new List<string>();
      }
      _headers[key].Add(value);
    }

    public void Apply(HttpClient httpClient)
    {
      httpClient.DefaultRequestHeaders.Clear();
      foreach (KeyValuePair<string, List<string>> header in _headers)
      {
        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
      }
    }
  }
}