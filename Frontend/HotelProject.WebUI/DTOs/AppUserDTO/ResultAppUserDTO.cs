using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.AppUserDTO
{
    public class ResultAppUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageURL { get; set; }
        public string WorkDepartment { get; set; }
        public int WorkLocationID { get; set; }
    }
}
