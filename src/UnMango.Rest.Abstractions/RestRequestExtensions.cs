using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    /// <summary>
    /// Extension methods for <see cref="IRestRequest"/>.
    /// </summary>
    public static class RestRequestExtensions
    {
        /// <summary>
        /// Executes the current REST request.
        /// </summary>
        /// <param name="request">The <see cref="IRestRequest"/> to be executed.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running tasks.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static Task ExecuteAsync(this IRestRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return request.Client.SendAsync(request, cancellationToken);
        }
    }
}
