using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _service;
        private readonly IMapper _mapper;
        public AboutUsController(IAboutUsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult AboutList()
        {
          var values=_mapper.Map<List<AboutUsResultDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetAboutUs(int id)
        {
            var values = _mapper.Map<AboutUsGetDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateAboutUs(AboutUsCreateDTO dto)
        {
            _service.Create(new AboutUs()
            {
                ImageUrl = dto.ImageUrl,
                Title = dto.Title,
                Description = dto.Description,
                Id= dto.Id,
            });

            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateAboutUs(AboutUsUpdateDTO dto)
        {
            _service.Update(new AboutUs()
            {
              ImageUrl= dto.ImageUrl,
                Title= dto.Title,
                Description= dto.Description,


            });
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult UpdateAboutUs(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
