using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Goldlight.Xlcr.Core
{
    public class Endpoint
    {
        public Endpoint(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint) || !IsHttpFormatEndpoint(endpoint))
            {
                throw new ArgumentException(null, nameof(endpoint));
            }
            Address = endpoint;
        }

        public string Address { get; }

        private bool IsHttpFormatEndpoint(string endpoint)
        {
            return new Regex(@"^\s*(http|https)://.*$", RegexOptions.IgnoreCase).IsMatch(endpoint);
        }
    }
}