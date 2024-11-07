using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingsRepository _bookingRepo;
        private readonly IRoomsRepository _roomsRepo;
        public BookingService(IBookingsRepository bookingRepo, IRoomsRepository roomsRepo)
        {
            _bookingRepo = bookingRepo;
            _roomsRepo = roomsRepo;
        }

        public bool IsBookingValid(int roomId, Booking booking)
        {
            var guestIsSmoking = booking.IsSmoking;
            var guestIsBringingPets = booking.HasPets;
            var numberOfGuests = booking.NumberOfGuests;

            return !guestIsSmoking;
        }

        public int CalculateBookingCost(int roomId, Booking booking)
        {
            return 0;
        }
    }
}
