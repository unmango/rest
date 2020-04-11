using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    /// <summary>
    /// A typed rest client abstraction.
    /// </summary>
    public interface IRestClient
    {
        Task<T> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken = default);

        Task<T> GetAsync<T>(Uri requestUri, CancellationToken cancellationToken = default);

        Task<TResult> PatchAsync<TRequest, TResult>(Uri requestUri, TRequest request, CancellationToken cancellationToken = default);

        Task<TResult> PostAsync<TRequest, TResult>(Uri requestUri, TRequest request, CancellationToken cancellationToken = default);

        Task<TResult> PutAsync<TRequest, TResult>(Uri requestUri, TRequest request, CancellationToken cancellationToken = default);
    }
}
