using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest
{
    public static class RestRequestExtensions
    {
        public static Task ExecuteAsync(this RestRequest request, CancellationToken cancellationToken = default)
        {
            return request.Client.SendAsync(request, cancellationToken);
        }
    }
}
