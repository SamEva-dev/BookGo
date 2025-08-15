
namespace BookGo.Contracts.Dtos;

public sealed record SearchHotelsRequest(string City, bool EcoOnly, int Page = 1, int PageSize = 10, DateOnly? CheckIn = null, DateOnly? CheckOut = null);
public sealed record HotelListItem(Guid Id, string Name, string City, decimal NightPrice, string Currency, bool EcoLabeled);
public sealed record PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize, int Total);