using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Porkbun.Client.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for Porkbun
/// </summary>
public static class PorkbunClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IPorkbunClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPorkbunClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddSingleton<IPorkbunClientUtil, PorkbunClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPorkbunClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPorkbunClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddScoped<IPorkbunClientUtil, PorkbunClientUtil>();

        return services;
    }
}
