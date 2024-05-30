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
        [HttpGet("GetById/{Id}")]
        public IActionResult GetReservation(int Id)
        {
            var values = _mapper.Map<GetReservationDTO>(_service.GetById(Id));
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
        [HttpPut("Update/{Id}")]
        public IActionResult UpdateReservation(int Id,UpdateReservationDTO dto)
        {
            var entity=_service.GetById(Id);
            _mapper.Map(dto, entity);
          _service.Update(entity);
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteReservation(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
