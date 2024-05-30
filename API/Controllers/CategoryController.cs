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
        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.GetList());
            return Ok(values);
        }
        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            var values = _mapper.Map<GetCategoryDTO>(_categoryService.GetById(Id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateCategory(AddCategoryDTO dto)
        {
            var entity= new Category();
            _mapper.Map(dto,entity);
            _categoryService.Create(entity);
            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateCategory(UpdateCategoryDTO dto)
        {
            if (dto.Id==null)
            {

                return NotFound("Bu məhsul bazada mövcud deyil");
            }
            var entity = _categoryService.GetById(dto.Id);
            if (entity==null)
            {
                return NotFound("Xəta baş verdi");
            }
            _mapper.Map(dto,entity);
            _categoryService.Update(entity);

            return Ok(entity);
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteCategroy(int Id)
        {
            var entity = _categoryService.GetById(Id);
            _categoryService.Delete(entity);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
       
    }
}
