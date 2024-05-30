using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.CategoryDTO;
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
        //[HttpGet("List")]
        //public IActionResult AboutList()
        //{
        //  var values=_mapper.Map<List<AboutUsResultDTO>>(_service.GetList());
        //    return Ok(values);    
        //}
        [HttpGet("GetById/{Id}")]
        public IActionResult GetAboutUs(int Id)
        {
            if (Id == null)
            {
                return NotFound("Haqqımızda səhifəsi tapılmadı!");
            }
            var values = _mapper.Map<AboutUsGetDTO>(_service.GetById(Id));
            
            return Ok(values);
        }
   
        [HttpPut("Update/{Id}")]
        public IActionResult UpdateAboutUs(int Id,AboutUsUpdateDTO dto)
        {
            var entity = _service.GetById(Id);
           
            _mapper.Map(dto,entity);
            _service.Update(entity);

            return Ok("Məlumatlar yeniləndi!");
        }
        //[HttpDelete("Delete")]
        //public IActionResult DeleteAboutUs(int  Id)
        //{
        //    var values = _service.GetById(Id);
        //    _service.Delete(values);

        //    return Ok("Silmə əməliyyatı uğurludur!");
        //}
    }
}
