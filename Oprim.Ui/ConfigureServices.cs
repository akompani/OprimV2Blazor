using Microsoft.EntityFrameworkCore;
using Oprim.Application;
using Oprim.Infrastructure;
using Oprim.Ui.Data;

namespace Oprim.Ui;

public static class ConfigureServices
{
    public static IServiceCollection AddUiServices(this IServiceCollection services)
    {
     
        services.AddDbContext<ApplicationDbContext>(s =>
            s.UseSqlServer("Data Source=94.232.174.250;Initial Catalog=mrmetror_ppn;Integrated Security=False;User ID=mrmetror;Password=@mirTala2019;Connect Timeout=15;Encrypt=False;Packet Size=4096"));
        services.AddAutoMapper(typeof(Program));
        return services;
    }
}