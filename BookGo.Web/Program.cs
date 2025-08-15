using BookGo.Application.Search;
using BookGo.Infrastructure;
using BookGo.Infrastructure.Db;

namespace BookGo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SearchHotelsQuery>());
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddOutputCache(o => o.AddPolicy("Short", p => p.Expire(TimeSpan.FromSeconds(15))));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

             db.Database.EnsureCreatedAsync();

            _ = AppDbContext.SeedAsync(db);
        }

        app.Run();
    }
}
