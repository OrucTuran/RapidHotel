using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.RoomDTO
{
    public class UpdateRoomDTO
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string WiFi { get; set; }
        public string Description { get; set; }
    }
}
