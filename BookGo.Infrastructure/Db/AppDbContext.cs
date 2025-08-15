using BookGo.Application.Abstractions;
using BookGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookGo.Infrastructure.Db;

public sealed class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<Booking> Bookings => Set<Booking>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Hotel>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
            e.Property(x => x.City).HasMaxLength(120).IsRequired();
            e.Property(x => x.Currency).HasMaxLength(3).IsRequired();
        });
        b.Entity<Booking>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Currency).HasMaxLength(3).IsRequired();
        });
    }

    public static async Task SeedAsync(AppDbContext db, CancellationToken ct = default)
    {
        if (!await db.Hotels.AnyAsync(ct))
        {
            db.Hotels.AddRange(
                new Hotel("Eco Riviera", "Nice", 120, true),
                new Hotel("Green Alps Lodge", "Chamonix", 150, true),
                new Hotel("City Comfort", "Paris", 180, false),
                new Hotel("Atlantic View", "Biarritz", 140, true)
            );
            await db.SaveChangesAsync(ct);
        }
    }
}