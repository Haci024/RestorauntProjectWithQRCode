using AutoMapper;
using AutoMapper.Features;
using DTO.DTOS.FeaturesDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class FeaturesMapper:Profile
    {
        public FeaturesMapper()
        {
            CreateMap<Features, AddFeaturesDTO>().ReverseMap();
            CreateMap<Features,UpdateFeaturesDTO>().ReverseMap();
            CreateMap<Features,GetFeaturesDTO>().ReverseMap();
            CreateMap<Features,ResultFeaturesDTO>().ReverseMap();


        }
    }
}
