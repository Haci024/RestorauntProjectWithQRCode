using AutoMapper;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.ReservationDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class AboutUsMapper:Profile
    {
        public AboutUsMapper()
        {
            CreateMap<AboutUs, AboutUsResultDTO>().ReverseMap();
            CreateMap<AboutUs, AboutUsCreateDTO>().ReverseMap();
            CreateMap<AboutUs, AboutUsGetDTO>().ReverseMap();
            CreateMap<AboutUs, AboutUsUpdateDTO>().ReverseMap();
        }
    }
}
