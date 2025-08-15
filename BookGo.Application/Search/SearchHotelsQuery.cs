using BookGo.Contracts.Dtos;
using MediatR;

namespace BookGo.Application.Search;

public sealed record SearchHotelsQuery(SearchHotelsRequest Request) : IRequest<PagedResult<HotelListItem>>;