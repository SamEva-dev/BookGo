using BookGo.Application.Abstractions;
using BookGo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookGo.Application.Bookings;

public sealed class CreateDraftBookingHandler : IRequestHandler<CreateDraftBookingCommand, Guid>
{
    private readonly IAppDbContext _db;
    public CreateDraftBookingHandler(IAppDbContext db) => _db = db;

    public async Task<Guid> Handle(CreateDraftBookingCommand cmd, CancellationToken ct)
    {
        var hotel = await _db.Hotels.AsNoTracking().FirstOrDefaultAsync(h => h.Id == cmd.HotelId, ct)
                    ?? throw new InvalidOperationException("Hotel not found");

        var nights = cmd.CheckOut.DayNumber - cmd.CheckIn.DayNumber;
        if (nights <= 0) throw new InvalidOperationException("Dates invalides");

        var total = hotel.NightPrice * nights;
        var booking = new Booking(cmd.UserId, cmd.HotelId, cmd.CheckIn, cmd.CheckOut, total, hotel.Currency);
        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync(ct);
        return booking.Id;
    }
}