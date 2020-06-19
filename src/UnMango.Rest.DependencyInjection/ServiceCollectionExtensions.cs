using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestClient(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            return services;
        }
    }
}
