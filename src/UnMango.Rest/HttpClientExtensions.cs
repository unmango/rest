using System;
using System.Net.Http;

namespace UnMango.Rest
{
    /// <summary>
    /// Extension methods for <see cref="HttpClient"/>.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Initiates a REST request using <paramref name="httpClient"/> as the client.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to use to execute the request.</param>
        /// <returns>An initialized <see cref="RestRequest"/>.</returns>
        public static RestRequest Request(this HttpClient httpClient)
        {
            //var client = new RestClient(
            //    httpClient,
            //    new SerializerCollection());

            //return new RestRequest(client);
            throw new NotImplementedException();
        }
    }
}
