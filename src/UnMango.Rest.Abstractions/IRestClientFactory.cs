using JetBrains.Annotations;

namespace UnMango.Rest;

/// <summary>
/// Abstraction for creating <see cref="IRestClient"/>s.
/// </summary>
[PublicAPI]
public interface IRestClientFactory
{
    /// <summary>
    /// Creates a <see cref="IRestClient"/> with configuration corresponding to <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name of the <see cref="IRestClient"/> to create.</param>
    /// <returns>The configured <see cref="IRestClient"/>.</returns>
    IRestClient Create(string name);
}
