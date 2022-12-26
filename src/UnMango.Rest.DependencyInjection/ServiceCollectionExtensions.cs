﻿using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace UnMango.Rest.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
[PublicAPI]
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
        // services.AddOptions<RestClientOptions>();

        // Library types
        // services.AddTransient<IRestClientFactory, DefaultRestClientFactory>();
        services.AddTransient(CreateDefaultRestClient);

        return services;
    }

    public static IRestClientBuilder AddRestClient(this IServiceCollection services, string name)
    {
        return new DefaultRestClientBuilder(services.AddRestClient().AddHttpClient(name));
    }

    private static IRestClient CreateDefaultRestClient(IServiceProvider services)
    {
        return services.GetRequiredService<IRestClientFactory>().Create(string.Empty);
    }
}
