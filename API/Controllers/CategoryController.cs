using AutoMapper;
using Business.Services;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.CategoryDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService=categoryService;
            _mapper=mapper;
            
        }
        [HttpGet("List")]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.GetList());
            return Ok(values);
        }
        [HttpGet("/GetById/{Id}")]
        public IActionResult GetAboutUs(int id)
        {
            var values = _mapper.Map<GetCategoryDTO>(_categoryService.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateAboutUs(AddCategoryDTO dto)
        {
            _categoryService.Create(new Category()
            {
                Name = dto.Name,
                Status = dto.Status,
                Id = dto.Id,
            });
            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateAboutUs(Category entity)
        {



            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult UpdateAboutUs(int Id)
        {
            var values = _categoryService.GetById(Id);
            _categoryService.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
