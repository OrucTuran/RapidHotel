using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.Room_DTO
{
    public class RoomAddDTO
    {
        //public int ID { get; set; } // ekleme islemi icin id ye gerek yok
        [Required(ErrorMessage = "Lütfen oda numarasını giriniz.")]
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisi giriniz.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisi giriniz.")]
        public string BathCount { get; set; }
        public string WiFi { get; set; }
        public string Description { get; set; }
    }
}
