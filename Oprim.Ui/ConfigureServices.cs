using Microsoft.EntityFrameworkCore;
using Oprim.Application;
using Oprim.Infrastructure;

namespace Oprim.Ui;

public static class ConfigureServices
{
    public static IServiceCollection AddUiServices(this IServiceCollection services)
    {
        services.AddDbContext<Domain.Database.ApplicationDbContext>(s =>
            s.UseSqlServer("Server=DESKTOP-46S8RHK;Database=oprim;Trusted_Connection=True;TrustServerCertificate=True;"));
        services.AddAutoMapper(typeof(Program));
        return services;
    }
}