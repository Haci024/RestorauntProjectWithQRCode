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
        [HttpGet("GetById")]
        public IActionResult GetAboutUs(int id)
        {
            var values = _mapper.Map<GetOffersDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateOffers(AddOffersDTO dto)
        {
            _service.Create(new Offers()
            {
                Description = dto.Description,
                Image=dto.Image,
                Name=dto.Name,
                rate=dto.rate,

                Id= dto.Id,
            });


            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateAboutUs(UpdateOffersDTO dto)
        {
            _service.Update(new Offers()
            {
                Description = dto.Description,
                Image = dto.Image,
                Name = dto.Name,
                rate = dto.rate,
                Id = dto.Id,
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
