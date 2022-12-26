using JetBrains.Annotations;

namespace UnMango.Rest;

/// <summary>
/// Extension methods for <see cref="IRestRequest"/>.
/// </summary>
[PublicAPI]
public static class RestRequestExtensions
{
    /// <summary>
    /// Executes the current REST request.
    /// </summary>
    /// <param name="request">The <see cref="IRestRequest"/> to be executed.</param>
    /// <param name="cancellationToken">Used to signal cancellation to running tasks.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task<IRestResponse> ExecuteAsync(this IRestRequest request, CancellationToken cancellationToken = default)
        => request.Client.SendAsync(request, cancellationToken);
}
