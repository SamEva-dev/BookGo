using BookGo.Application.Abstractions;
using BookGo.Contracts.Dtos;
using MediatR;

namespace BookGo.Application.Search;

public sealed class SearchHotelsHandler : IRequestHandler<SearchHotelsQuery, PagedResult<HotelListItem>>
{
    private readonly IHotelSearch _search;
    public SearchHotelsHandler(IHotelSearch search) => _search = search;

    public Task<PagedResult<HotelListItem>> Handle(SearchHotelsQuery q, CancellationToken ct)
        => _search.SearchAsync(q.Request, ct);
}