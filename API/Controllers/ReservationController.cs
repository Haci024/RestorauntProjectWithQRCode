using AutoMapper;
using Business.Service;
using Business.Services;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.ReservationDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult ReservationList()
        {
          var values=_mapper.Map<List<ResultReservationDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetReservation(int id)
        {
            var values = _mapper.Map<GetReservationDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateReservation(AddReservationDTO dto)
        {
            _service.Create(new Reservation()
            {
                Date = dto.Date,
                Email = dto.Email,
                Name = dto.Name,
                Id = dto.Id,
                PersonCount=dto.PersonCount,
                PhoneNumber=dto.PhoneNumber,

            });


            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateReservation(UpdateReservationDTO dto)
        {
            _service.Update(new Reservation()
            {
                Date = dto.Date,
                Email = dto.Email,
                Name = dto.Name,
                Id = dto.Id,
                PersonCount = dto.PersonCount,
                PhoneNumber = dto.PhoneNumber
            });
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteReservation(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
