using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.AboutDTO;
using HotelProject.WebUI.DTOs.LoginDTO;
using HotelProject.WebUI.DTOs.RegisterDTO;
using HotelProject.WebUI.DTOs.ServiceDTO;
using HotelProject.WebUI.DTOs.StaffDTO;
using HotelProject.WebUI.DTOs.SubscribeDTO;
using HotelProject.WebUI.DTOs.TestimonialDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
            CreateMap<CreateServiceDTO, Service>().ReverseMap();

            CreateMap<CreateNewUserDTO, AppUser>().ReverseMap();
            CreateMap<LoginUserDTO, AppUser>().ReverseMap();

            CreateMap<ResultAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();

            CreateMap<ResultTestimonialDTO, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDTO, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDTO, Subscribe>().ReverseMap();

        }
    }
}
