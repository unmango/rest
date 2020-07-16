using System;
using System.Collections.Generic;
using System.Net.Http;
using UnMango.Rest.Internal;

namespace UnMango.Rest
{
    /// <summary>
    /// Represents a REST request.
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
        public RestRequest(IRestClient client, HttpMethod method) : this(client)
        {
            Method = method;
            QueryParameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="RestRequest"/> that will use
        /// <paramref name="client"/> to execute a <paramref name="method"/> request
        /// with <paramref name="queryParameters"/> as parameters.
        /// </summary>
        /// <param name="client">The <see cref="IRestClient"/> to use to execute the request.</param>
        /// <param name="method">The <see cref="HttpMethod"/> the request will use.</param>
        /// <param name="queryParameters">The query parameters to send with the request.</param>
        public RestRequest(
            IRestClient client,
            HttpMethod method,
            IEnumerable<KeyValuePair<string, string>> queryParameters)
            : this(client, method)
        {
            if (queryParameters == null) throw new ArgumentNullException(nameof(queryParameters));
            
            QueryParameters = new Dictionary<string, string>(queryParameters.ToDictionary());
        }
        
        /// <inheritdoc />
        public IRestClient Client { get; }

        /// <inheritdoc />
        public HttpMethod? Method { get; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> QueryParameters { get; }

        /// <inheritdoc />
        public string Uri { get; }
    }
}
