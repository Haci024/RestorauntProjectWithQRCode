using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.ContactUsDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _service;
        private readonly IMapper _mapper;
        public ContactUsController(IContactUsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult ContactUsList()
        {
          var values=_mapper.Map<List<ResultContactUsDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetContactUs(int id)
        {
            var values = _mapper.Map<GetContactUsDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateContactUs(AddContactUsDTO dto)
        {
            _service.Create(new ContactUs()
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description,
                Location = dto.Location,
                Id = dto.Id,
            });


            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateContactUs(UpdateContactUsDTO dto)
        {
            _service.Update(new ContactUs()
            {
              Email= dto.Email,
                PhoneNumber= dto.PhoneNumber,
                Description= dto.Description,
                Location= dto.Location,
            });
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult UpdateContactUs(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
