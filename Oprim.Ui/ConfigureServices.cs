using Microsoft.EntityFrameworkCore;
using Oprim.Application;
using Oprim.Infrastructure;

namespace Oprim.Ui;

public static class ConfigureServices
{
    public static IServiceCollection AddUiServices(this IServiceCollection services)
    {
        services.AddDbContext<Domain.Database.ApplicationDbContext>(s =>
            s.UseSqlServer("Data Source=185.2.14.61\\MSSQLSERVER2022;Initial Catalog=oprim_test_blazor;Integrated Security=False;User ID=oprim_blazor;Password=Blazor2025;Connect Timeout=15;Encrypt=False;Packet Size=4096"));
        services.AddAutoMapper(typeof(Program));
        return services;
    }
}