using Microsoft.Extensions.DependencyInjection;
using Oprim.Application.Interfaces;
using Oprim.Infrastructure.Repositories;
using StackExchange.Redis;

namespace Oprim.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFileService,FileService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IConnectionMultiplexer>(_ =>
        {
            var configOptions = new ConfigurationOptions
            {
                EndPoints = { "185.165.118.72:6379" },
                ConnectTimeout = 5000,
                AbortOnConnectFail = false
            };
            return ConnectionMultiplexer.Connect(configOptions);
        });
        services.AddScoped<IResponseCacheService, ResponseCacheService>();
        return services;
    }
}