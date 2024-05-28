using AutoMapper;
using DTO.DTOS.CategoryDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
        }
    }
}
