using JetBrains.Annotations;

namespace UnMango.Rest;

/// <summary>
/// A typed rest client abstraction.
/// </summary>
[PublicAPI]
public interface IRestClient
{
    /// <summary>
    /// Gets the <see cref="HttpClient"/> used by the <see cref="IRestClient"/>.
    /// </summary>
    HttpClient HttpClient { get; }

    /// <summary>
    /// Sends an <see cref="IRestRequest"/> asynchronously and returns the <see cref="IRestResponse"/>.
    /// </summary>
    /// <param name="request">The <see cref="IRestRequest"/> to send.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> using to signal cancellation to the asynchronous operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.</returns>
    Task<IRestResponse> SendAsync(IRestRequest request, CancellationToken cancellationToken = default);
}
