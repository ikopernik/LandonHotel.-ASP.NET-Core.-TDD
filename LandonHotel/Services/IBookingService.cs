using LandonHotel.Data;

namespace LandonHotel.Services
{
    public interface IBookingService
    {
        decimal CalculateBookingPrice(Booking booking);
    }
}