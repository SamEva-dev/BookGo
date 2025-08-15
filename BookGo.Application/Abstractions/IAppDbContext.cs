
using BookGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookGo.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Hotel> Hotels { get; }
    DbSet<Booking> Bookings { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}