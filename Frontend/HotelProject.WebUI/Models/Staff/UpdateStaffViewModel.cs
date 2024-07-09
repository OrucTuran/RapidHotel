using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Models.Staff
{
    public class UpdateStaffViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocialMedia_A { get; set; }
        public string SocialMedia_B { get; set; }
        public string SocialMedia_C { get; set; }
    }
}
