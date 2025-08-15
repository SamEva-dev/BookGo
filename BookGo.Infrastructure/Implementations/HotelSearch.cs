using BookGo.Application.Abstractions;
using BookGo.Contracts.Dtos;
using BookGo.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace BookGo.Infrastructure.Implementations;

public sealed class HotelSearch : IHotelSearch
{
    private readonly AppDbContext _db;
    public HotelSearch(AppDbContext db) => _db = db;

    public async Task<PagedResult<HotelListItem>> SearchAsync(SearchHotelsRequest req, CancellationToken ct)
    {
        var q = _db.Hotels.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(req.City))
            q = q.Where(h => h.City.ToLower().Contains(req.City.ToLower()));

        if (req.EcoOnly)
            q = q.Where(h => h.EcoLabeled);

        var total = await q.CountAsync(ct);
        var items = await q.OrderBy(h => h.NightPrice)
                           .Skip((req.Page - 1) * req.PageSize)
                           .Take(req.PageSize)
                           .Select(h => new HotelListItem(h.Id, h.Name, h.City, h.NightPrice, h.Currency, h.EcoLabeled))
                           .ToListAsync(ct);

        return new(items, req.Page, req.PageSize, total);
    }
}