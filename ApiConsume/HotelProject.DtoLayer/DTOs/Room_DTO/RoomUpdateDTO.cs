using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.Room_DTO
{
    public class RoomUpdateDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarasını giriniz.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görseli giriniz.")]
        public string CoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz.")]
        [Range(0, 10000, ErrorMessage = "Fiyat 0 ile 10000 arasında olmalıdır.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz.")]
        [StringLength(100,ErrorMessage ="Lütfen en fazla 100 karakter veri girişi yapınız.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisi giriniz.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisi giriniz.")]
        public string BathCount { get; set; }

        [Required(ErrorMessage = "Lütfen Wi-Fi bilgisi giriniz.")]
        [RegularExpression(@"^(Evet|Hayır)$", ErrorMessage = "Wi-Fi bilgisi 'Evet' veya 'Hayır' olmalıdır.")]
        public string WiFi { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama bilgisi giriniz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }

    }
}
