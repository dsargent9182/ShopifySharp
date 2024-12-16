#nullable enable
using System;

namespace ShopifySharp.Infrastructure;

internal static class InternalServiceResolver
{
    public static TService? GetService<TService>(IServiceProvider? serviceProvider) where TService : class
    {
        var service = serviceProvider?.GetService(typeof(TService));
        return service as TService ?? null;
    }

    public static TService GetServiceOrDefault<TService>(IServiceProvider? serviceProvider, Func<TService> createDefaultService)
    {
        var service = serviceProvider?.GetService(typeof(TService));
        return service is not null ? (TService)service : createDefaultService.Invoke();
    }
}
