using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Rest.Serialization;

namespace UnMango.Rest
{
    /// <summary>
    /// A typed rest client abstraction.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Gets the <see cref="HttpClient"/> used by the <see cref="IRestClient"/>.
        /// </summary>
        HttpClient HttpClient { get; }
        
        /// <summary>
        /// Gets the collection of <see cref="ISerializer"/>s configured for the <see cref="IRestClient"/>.
        /// </summary>
        ISerializerCollection Serializers { get; }

        Task SendAsync(IRestRequest request, CancellationToken cancellationToken = default);
    }
}
