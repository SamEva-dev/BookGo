
namespace BookGo.Domain.Entities;

public enum BookingStatus { Draft, Confirmed, Cancelled }

public sealed class Booking
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public Guid HotelId { get; private set; }
    public DateOnly CheckIn { get; private set; }
    public DateOnly CheckOut { get; private set; }
    public BookingStatus Status { get; private set; } = BookingStatus.Draft;
    public decimal Total { get; private set; }
    public string Currency { get; private set; } = "EUR";

    private Booking() { }
    public Booking(Guid userId, Guid hotelId, DateOnly checkIn, DateOnly checkOut, decimal total, string currency = "EUR")
    {
        UserId = userId;
        HotelId = hotelId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Total = total;
        Currency = currency;
    }

    public void Confirm() => Status = BookingStatus.Confirmed;
}