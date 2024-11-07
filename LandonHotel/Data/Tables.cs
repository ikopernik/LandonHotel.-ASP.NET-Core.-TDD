using System;
using System.Collections.Generic;

namespace LandonHotel.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }

    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomId { get; set; }
        public string CouponCode { get; set; }
    }

    public class Coupon
    {
        public string Code { get; set; }
        public decimal PercentageDiscount { get; set; }
    }
}
