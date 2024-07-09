using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.LoginDTO
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage = "Kullanıcı adını giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
    }
}
