using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;

namespace Oprim.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetPunchesQuery).Assembly));

        return services;
    }
}