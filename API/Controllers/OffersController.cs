using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.OffersDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService _service;
        private readonly IMapper _mapper;
        public OffersController(IOffersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult OffersList()
        {
          var values=_mapper.Map<List<ResultOffersDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById/{Id}")]
        public IActionResult GetAboutUs(int id)
        {
            var values = _mapper.Map<GetOffersDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateOffers(AddOffersDTO dto)
        {
          Offers entity=new();
            _mapper.Map(dto,entity);
            _service.Create(entity);
            
            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update/{Id}")]
        public IActionResult Update(int Id,UpdateOffersDTO dto)
        {
            var entity = _service.GetById(Id);
            _mapper.Map(dto,entity);
           
            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
