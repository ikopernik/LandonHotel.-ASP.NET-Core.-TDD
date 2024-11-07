using LandonHotel.Services;
using LandonHotel.Data;
using LandonHotel.Repositories;
using Moq;

namespace LandonHotel.Tests
{
    public class BookingServiceTests
    {
        private Mock<IRoomsRepository> _roomRepo;

        public BookingServiceTests()
        {
            _roomRepo = new Mock<IRoomsRepository>();
        }

        private BookingService Subject()
        {
            return new BookingService(null, _roomRepo.Object);
        }

        [Fact]
        public void IsBookingValid_NonSmoker_Valid()
        {
            var service = new BookingService(null, null);
            var isValid = service.IsBookingValid(
                1,
                new Booking
                {
                    IsSmoking = false
                });

            Assert.True(isValid);
        }

        [Fact]
        public void IsBookingValid_Smoker_Invalid()
        {
            var service = new BookingService(null, null);
            var isValid = service.IsBookingValid(
                1,
                new Booking
                {
                    IsSmoking = true
                });

            Assert.False(isValid);
        }

        [Fact]
        public void IsBookingValid_PetsNotAllowed_Invalid()
        {
            var service = Subject();
            _roomRepo.Setup(x => x.GetRoom(1)).Returns(new Room
            {
                ArePetsAllowed = false
            });

            var isValid = service.IsBookingValid(
                1,
                new Booking
                {
                    HasPets = true
                });

            Assert.False(isValid);
        }
    }
}
