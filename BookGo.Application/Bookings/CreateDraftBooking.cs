using MediatR;

namespace BookGo.Application.Bookings;

public sealed record CreateDraftBookingCommand(Guid UserId, Guid HotelId, DateOnly CheckIn, DateOnly CheckOut) : IRequest<Guid>;