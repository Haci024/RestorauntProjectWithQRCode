using AutoMapper;
using DTO.DTOS.OffersDTO;
using DTO.DTOS.SocialMediaDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class SocialMediaMapper:Profile
    {
        public SocialMediaMapper()
        {
            CreateMap<SocialMedia, AddSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
        }
    }
}
