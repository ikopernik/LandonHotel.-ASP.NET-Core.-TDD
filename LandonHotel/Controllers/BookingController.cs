using System;
using LandonHotel.Data;
using LandonHotel.Models;
using LandonHotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandonHotel.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public BookingController(IRoomService roomService, IBookingService bookingService)
        {
            this._roomService = roomService;
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new BookingViewModel()
            {
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1),
                Rooms = _roomService.GetAllRooms()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Rooms = _roomService.GetAllRooms();
                ViewBag.ErrorMessage = "Booking was not valid";
                return View("Index", model);
            }

            var booking = new Booking()
            {
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                RoomId = model.RoomId,
                CouponCode = model.CouponCode
            };

            return View("Success",
                new BookingSuccessViewModel
                {
                    Price = _bookingService.CalculateBookingPrice(booking)
                });
        }
    }
}
