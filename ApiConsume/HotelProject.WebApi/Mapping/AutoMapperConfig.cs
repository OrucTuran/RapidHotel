using AutoMapper;
using HotelProject.DtoLayer.DTOs.Room_DTO;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile//dto larimiz ile entitylerimiz baglayacigimiz sinif
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDTO, Room>();
            CreateMap<Room, RoomAddDTO>();

            CreateMap<RoomUpdateDTO, Room>().ReverseMap();
        }
    }
}
//mapleme islemi sayesinde; dto sinifinda gecmis oldugumuz properylerimizle entity sinifindaki propertylerimiz birbiri ile eslesmis olacak