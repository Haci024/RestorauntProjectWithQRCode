using AutoMapper;
using Business.Service;
using DTO.DTOS.AboutDTO;
using DTO.DTOS.FeaturesDTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeaturesService _service;
        private readonly IMapper _mapper;
        public FeaturesController(IFeaturesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet("List")]
        public IActionResult FeaturesList()
        {
          var values=_mapper.Map<List<ResultFeaturesDTO>>(_service.GetList());
            return Ok(values);    
        }
        [HttpGet("GetById")]
        public IActionResult GetFeatures(int id)
        {
            var values = _mapper.Map<GetFeaturesDTO>(_service.GetById(id));
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateFeatures(AddFeaturesDTO dto)
        {
            _service.Create(new Features()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
            });


            return Ok("Əlavə edildi!");
        }
        [HttpPut("Update")]
        public IActionResult UpdateFeatures(UpdateFeaturesDTO dto)
        {
            _service.Update(new Features()
            {
              Id= dto.Id,
                Title= dto.Title,
                Description= dto.Description,


            });
           

            return Ok("Məlumatlar yeniləndi!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteFeatures(int  Id)
        {
            var values = _service.GetById(Id);
            _service.Delete(values);

            return Ok("Silmə əməliyyatı uğurludur!");
        }
    }
}
