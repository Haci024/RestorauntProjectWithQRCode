using AutoMapper;
using DTO.DTOS.OffersDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class OffersMapper:Profile
    {
        public OffersMapper()
        {
            CreateMap<Offers, AddOffersDTO>().ReverseMap();
            CreateMap<Offers, UpdateOffersDTO>().ReverseMap();
            CreateMap<Offers, GetOffersDTO>().ReverseMap();
            CreateMap<Offers, ResultOffersDTO>().ReverseMap();
        }
      
    }
}
