using System;

namespace HotelProject.WebUI.DTOs.BookingDTO
{
    public class UpdateBookingDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecielRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
