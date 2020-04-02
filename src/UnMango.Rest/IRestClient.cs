using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    public interface IRestClient
    {
        Task<T> DeleteAsync<T>(string route, CancellationToken cancellationToken = default);

        Task<T> GetAsync<T>(string route, CancellationToken cancellationToken = default);

        Task<TResult> PatchAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken = default);

        Task<TResult> PostAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken = default);

        Task<TResult> PutAsync<TRequest, TResult>(string route, TRequest request, CancellationToken cancellationToken = default);
    }
}
