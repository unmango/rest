using System;
using Microsoft.Extensions.Options;

namespace UnMango.Rest
{
    /// <summary>
    /// Extension methods for <see cref="IRestClientFactory"/>.
    /// </summary>
    public static class RestClientFactoryExtensions
    {
        /// <summary>
        /// Creates a new <see cref="IRestClient"/> with the default configuration.
        /// </summary>
        /// <param name="factory">The <see cref="IRestClientFactory"/>.</param>
        /// <returns>An <see cref="IRestClient"/> using the default configuration.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory"/> is null.</exception>
        public static IRestClient Create(this IRestClientFactory factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            return factory.Create(Options.DefaultName);
        }
    }
}
