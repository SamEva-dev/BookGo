
using BookGo.Contracts.Dtos;

namespace BookGo.Application.Abstractions;

public interface IHotelSearch
{
    Task<PagedResult<HotelListItem>> SearchAsync(SearchHotelsRequest req, CancellationToken ct);
}