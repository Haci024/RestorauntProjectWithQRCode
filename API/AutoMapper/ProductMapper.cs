using AutoMapper;
using DTO.DTOS.ProductDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<Products,AddProductDTO>().ReverseMap();
            CreateMap<Products, GetProductDTO>().ReverseMap();
            CreateMap<Products, ResultProductDTO>().ReverseMap();
            CreateMap<Products, UpdateProductDTO>().ReverseMap();
        }
    }
}
