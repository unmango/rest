using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace UnMango.Rest
{
    /// <summary>
    /// A REST request abstraction.
    /// </summary>
    public interface IRestRequest
    {
        /// <summary>
        /// Gets the client to execute the request.
        /// </summary>
        IRestClient Client { get; }
        
        /// <summary>
        /// Gets the <see cref="HttpMethod"/> of the request.
        /// </summary>
        HttpMethod? Method { get; }
        
        /// <summary>
        /// Gets the query parameters for the request.
        /// </summary>
        IReadOnlyDictionary<string, string> QueryParameters { get; }

        /// <summary>
        /// Gets the URI for the request.
        /// </summary>
        /// string Uri { get; }
    }
}
