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
        [HttpGet("GetById/{Id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _mapper.Map<GetTestimonialDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateTestimonial(AddTestimonialDTO dto)
        {
         Testimonial entity=new Testimonial();
          
            _mapper.Map(dto, entity);
            _service.Create(entity);

            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO dto)
        {
            var entity=_service.GetById(dto.Id);
           
            _mapper.Map(dto, entity);
            _service.Update(entity);

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteTestimonial(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
