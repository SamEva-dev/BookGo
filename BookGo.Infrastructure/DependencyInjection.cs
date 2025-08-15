using BookGo.Application.Abstractions;
using BookGo.Infrastructure.Db;
using BookGo.Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookGo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AppDbContext>(o =>
            o.UseSqlite(cfg.GetConnectionString("Sqlite") ?? "Data Source=Data/bookgo.db"));
        services.AddScoped<IHotelSearch, HotelSearch>();
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
        return services;
    }
}