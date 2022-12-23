using System;
using System.Net.Http;
using UnMango.Rest.Serialization;

namespace UnMango.Rest
{
    using InternalRestClient = Internal.RestClient;
    
    /// <summary>
    /// Helper class for creating <see cref="IRestClient"/>s.
    /// </summary>
    public static class RestClient
    {
        /// <summary>
        /// Creates an <see cref="IRestClient"/> that will use <paramref name="client"/> to send requests
        /// and <paramref name="serializers"/> to serialize requests and deserialize responses.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="serializers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IRestClient Create(HttpClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            
            return new InternalRestClient(client);
        }
    }
}
