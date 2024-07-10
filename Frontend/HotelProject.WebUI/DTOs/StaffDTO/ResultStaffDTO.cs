using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.StaffDTO
{
    public class ResultStaffDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string SocialMedia_A { get; set; }
        public string SocialMedia_B { get; set; }
        public string SocialMedia_C { get; set; }
    }
}
