using System;

namespace Goldlight.Xlcr.Core
{
    public class GetRequest
    {
        public object Execute(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ArgumentException();
            }
            return new NotImplementedException();
        }
    }
}