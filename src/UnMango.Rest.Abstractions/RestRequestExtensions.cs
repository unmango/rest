using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    /// <summary>
    /// Extension methods for <see cref="IRestRequest"/>.
    /// </summary>
    public static class RestRequestExtensions
    {
        public static Task ExecuteAsync(this IRestRequest request, CancellationToken cancellationToken = default)
        {
            return request.Client.SendAsync(request, cancellationToken);
        }
    }
}
