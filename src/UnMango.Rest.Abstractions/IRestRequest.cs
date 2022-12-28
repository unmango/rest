using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace UnMango.Rest;

/// <summary>
/// A REST request abstraction.
/// </summary>
[PublicAPI]
public interface IRestRequest
{
    /// <summary>
    /// Gets the client to execute the request.
    /// </summary>
    IRestClient Client { get; }

    /// <summary>
    /// Gets the <see cref="HttpMethod"/> of the request.
    /// </summary>
    HttpMethod? Method { get; }

    /// <summary>
    /// Gets the query parameters for the request.
    /// </summary>
    IReadOnlyDictionary<string, string> QueryParameters { get; }

    /// <summary>
    /// Gets the URI for the request.
    /// </summary>
    Uri Uri { get; }

    /// <summary>
    /// Executes this <see cref="IRestRequest"/> and gets an awaiter used to await the resulting <see cref="Task{TResult}"/>.
    /// </summary>
    /// <returns>An awaiter used to await the request <see cref="Task{TResult}"/></returns>
    TaskAwaiter<IRestResponse> GetAwaiter();
}
