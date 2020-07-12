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
        /// <summary>
        /// Initializes a new instance of a <see cref="RestRequest"/> that will use
        /// <paramref name="client"/> to execute a REST request.
        /// </summary>
        /// <param name="client">The <see cref="IRestClient"/> to use to execute the request.</param>
        public RestRequest(IRestClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            QueryParameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="RestRequest"/> that will use
        /// <paramref name="client"/> to execute a <paramref name="method"/> request.
        /// </summary>
        /// <param name="client">The <see cref="IRestClient"/> to use to execute the request.</param>
        /// <param name="method">The <see cref="HttpMethod"/> the request will use.</param>
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
