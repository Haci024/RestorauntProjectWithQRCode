using AutoMapper;
using Business.Service;
using Business.Services;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.ProductDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult ProductList()
        {
          var values=_mapper.Map<List<ResultProductDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetProduct(int id)
        {
            var values = _mapper.Map<GetProductDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateProduct(AddProductDTO dto)
        {
            _service.Create(new Products()
            {
                Id=dto.Id,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description=dto.description,
                Status= dto.Status,
                Image=dto.Image,
                

                
            });


            return Ok("Məhsul əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateProduct(int id,UpdateProductDTO dto)
        {
            var value = _service.GetById(id);
            

            value.Id = dto.Id;
            value.CategoryId = dto.CategoryId;
            value.Name = dto.Name;
            value.Image = dto.Image;
            value.Description = dto.description;
            value.Status = dto.Status;

            _service.Update(value);



            return Ok("Məhsul məlumatları yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Məhsul uğurla silindi!");
        }
    }
}
