using System.Net.Http;

namespace UnMango.Rest.Internal
{
    /// <summary>
    /// Represents an abstraction for creating <see cref="HttpClient"/>s.
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Creates an <see cref="HttpClient"/> with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="HttpClient"/> to create.</param>
        /// <returns>An <see cref="HttpClient"/> configured for <paramref name="name"/>.</returns>
        public HttpClient CreateClient(string name);
    }
}
