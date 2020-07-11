using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace UnMango.Rest
{
    /// <summary>
    /// A REST request.
    /// </summary>
    public sealed class RestRequest : IRestRequest
    {
        public RestRequest(IRestClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            QueryParameters = new Dictionary<string, string>();
        }

        public RestRequest(IRestClient client, HttpMethod method)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Method = method;
            QueryParameters = new Dictionary<string, string>();
        }
        
        /// <inheritdoc />
        public IRestClient Client { get; }

        /// <inheritdoc />
        public HttpMethod? Method { get; } = null;

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> QueryParameters { get; }
    }
}
