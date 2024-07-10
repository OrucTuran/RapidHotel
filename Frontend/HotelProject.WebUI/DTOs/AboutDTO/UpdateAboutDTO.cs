using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.AboutDTO
{
    public class UpdateAboutDTO
    {
        public int ID { get; set; }
        public string TitleA { get; set; }
        public string TitleB { get; set; }
        public string Content { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
