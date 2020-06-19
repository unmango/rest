using System;
using System.Collections.Generic;
using System.Text;
using UnMango.Rest;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IRestClientFactory"/> and related serviced to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRestClient(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // External services
            services.AddLogging();
            services.AddOptions();
            services.AddHttpClient();

            // External configuration
            services.AddOptions<RestClientOptions>();

            return services;
        }
    }
}
