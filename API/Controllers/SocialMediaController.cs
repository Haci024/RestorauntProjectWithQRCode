using AutoMapper;
using Business.Service;
using DTO.DTOS.ReservationDTO;
using DTO.DTOS.SocialMediaDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaService _service;
        public SocialMediaController(ISocialMediaService service,IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("GetList")]
        public IActionResult GetSocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDTO>>(_service.GetList());
            return Ok(value);
        }
        [HttpGet("GetById/{Id}")]
        public IActionResult GetSocialMedia(int Id)
        {
            var value = _mapper.Map<GetSocialMediaDTO>(_service.GetById(Id));

            return Ok(value);
        }
        [HttpPost("Create")]
        public IActionResult CreateSocialMedia(AddSocialMediaDTO dto)
        {
            _service.Create(new SocialMedia()
            {
              
                Id = dto.Id,
                Icon=dto.Icon
            });
            return Ok("Social Media added sucessfully!");
        }
        [HttpPut("Update/{Id}")]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO dto)
        {
            _service.Create(new SocialMedia()
            {
                Id = dto.Id,
                Icon = dto.Icon,
            });
            return Ok("Social Media updatated Succesfully!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteSocialMedia(int Id)
        {
            var value=_service.GetById(Id);
            _service.Delete(value);
            return Ok("Social Media  deleted sucessfully!");
        }
    }
}
