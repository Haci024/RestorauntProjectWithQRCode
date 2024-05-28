using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.TestimonialDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult TestimonialList()
        {
          var values=_mapper.Map<List<ResultTestimonialDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _mapper.Map<GetTestimonialDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateTestimonial(AddTestimonialDTO dto)
        {
            _service.Create(new Testimonial()
            {
                Id = dto.Id,
                Title = dto.Title,
                Name = dto.Name,
                Comment = dto.Comment,
                ImageUrl = dto.ImageUrl,
                Status = dto.Status,

            });


            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO dto)
        {
            _service.Update(new Testimonial()
            {
           Id=dto.Id,
           Title=dto.Title,
           Name=dto.Name,
           Comment=dto.Comment,
           ImageUrl=dto.ImageUrl,
           Status=dto.Status,   


            });
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteTestimonial(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
