using System;
using LandonHotel.Data;
using LandonHotel.Models;
using LandonHotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandonHotel.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomService roomService;

        public BookingController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new BookingViewModel()
            {
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1),
                Rooms = roomService.GetAllRooms()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Success");
            }

            model.Rooms = roomService.GetAllRooms();
            ViewBag.ErrorMessage = "Booking was not valid";

            return View("Index", model);
        }
    }
}
