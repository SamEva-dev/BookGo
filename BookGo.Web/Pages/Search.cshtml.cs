using BookGo.Application.Search;
using BookGo.Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookGo.Web.Pages;

public class SearchModel : PageModel
{
    private readonly IMediator _mediator;
    public PagedResult<HotelListItem>? Result { get; private set; }

    public SearchModel(IMediator mediator) => _mediator = mediator;

    public async Task<PartialViewResult> OnGetAsync([FromQuery] SearchHotelsRequest req, CancellationToken ct)
    {
        Result = await _mediator.Send(new SearchHotelsQuery(req), ct);
        return Partial("_SearchResults", Result);
    }
}