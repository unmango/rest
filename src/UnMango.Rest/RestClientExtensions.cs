using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    /// <summary>
    /// Extensions for <see cref="IRestClient"/>
    /// </summary>
    public static class RestClientExtensions
    {
        public static Task<T> DeleteAsync<T>(
            this IRestClient client,
            Uri requestUri,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task<T> DeleteAsync<T>(
            this IRestClient client,
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            return client.DeleteAsync<T>(new Uri(requestUri), cancellationToken);
        }

        public static Task<T> GetAsync<T>(
            this IRestClient client,
            Uri requestUri,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task<T> GetAsync<T>(
            this IRestClient client,
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            return client.GetAsync<T>(new Uri(requestUri), cancellationToken);
        }

        public static Task<TResult> PatchAsync<TRequest, TResult>(
            this IRestClient client,
            Uri requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task<TResult> PatchAsync<TRequest, TResult>(
            this IRestClient client,
            string requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            return client.PatchAsync<TRequest, TResult>(new Uri(requestUri), request, cancellationToken);
        }

        public static Task<TResult> PostAsync<TRequest, TResult>(
            this IRestClient client,
            Uri requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task<TResult> PostAsync<TRequest, TResult>(
            this IRestClient client,
            string requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            return client.PostAsync<TRequest, TResult>(new Uri(requestUri), request, cancellationToken);
        }

        public static Task<TResult> PutAsync<TRequest, TResult>(
            this IRestClient client,
            Uri requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public static Task<TResult> PutAsync<TRequest, TResult>(
            this IRestClient client,
            string requestUri,
            TRequest request,
            CancellationToken cancellationToken = default)
        {
            return client.PutAsync<TRequest, TResult>(new Uri(requestUri), request, cancellationToken);
        }
    }
}
