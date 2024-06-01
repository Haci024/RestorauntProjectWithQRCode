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
          var values=_mapper.Map<IEnumerable<ResultProductDTO>>(_service.GetList());
            return Ok(values);    
        }
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var values = _mapper.Map<IEnumerable<ResultProductDTO>>(_service.ProductListWithCategory());
			return Ok(values);
		}
		[HttpGet("GetById/{Id}")]
        public IActionResult GetProduct(int Id)
        {
            var values = _mapper.Map<GetProductDTO>(_service.GetById(Id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateProduct(AddProductDTO dto)
        {
            var entity = new Products();
            
            _mapper.Map(dto,entity);
            _service.Create(entity);

            return Ok("Məhsul əlavə edildi!");
        }
        [HttpPut("Update/{Id}")]
        public IActionResult UpdateProduct(int Id,UpdateProductDTO dto)
        {
            var value = _service.GetById(Id);
           _mapper.Map(dto,value);
            _service.Update(value);

            return Ok("Məhsul məlumatları yeniləndi!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteProduct(int  Id)
        {

            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Məhsul uğurla silindi!");
        }

        [HttpGet("ProductListByCategory/{CategoryId}")]
        public IActionResult ProductListByCategory(int CategoryId)
        {
            var values = _mapper.Map<GetProductDTO>(_service.ProductListByCategory(CategoryId));


            return Ok(values);
        }
    }
}
