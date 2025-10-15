using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Oprim.Domain;

public static class ConfigureServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }
    
}