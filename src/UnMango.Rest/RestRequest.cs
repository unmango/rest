using System;
using System.Collections.Generic;
using System.Net.Http;

namespace UnMango.Rest
{
    public sealed class RestRequest : IRestRequest
    {
        private readonly Dictionary<string, string> _queryParameters;
        
        public RestRequest(IRestClient client)
        {
            _queryParameters = new Dictionary<string, string>();
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }
        
        public IRestClient Client { get; }

        HttpMethod? Method { get; }

        public IEnumerable<KeyValuePair<string, string>> QueryParameters => _queryParameters;
    }
}
