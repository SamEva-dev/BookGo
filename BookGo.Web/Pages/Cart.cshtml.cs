using BookGo.Application.Bookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookGo.Web.Pages;

public class CartModel : PageModel
{
    private readonly IMediator _mediator;
    public CartModel(IMediator mediator) => _mediator = mediator;

    public async Task<PartialViewResult> OnPostAsync([FromForm] Guid HotelId, [FromForm] DateOnly CheckIn, [FromForm] DateOnly CheckOut, CancellationToken ct)
    {
        // NOTE: en vrai, UserId = l'utilisateur connecté; ici, on simule
        var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        var bookingId = await _mediator.Send(new CreateDraftBookingCommand(userId, HotelId, CheckIn, CheckOut), ct);
        return Partial("_Cart", bookingId);
    }
}