using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.DTOs.ServiceDTO
{
    public class UpdateServiceDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Hizmet açıklaması en fazla 500 karakter olabilir.")]
        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        public string Description { get; set; }
    }
}