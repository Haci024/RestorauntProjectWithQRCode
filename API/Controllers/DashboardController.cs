using AutoMapper;
using Business.Service;
using Business.Services;
using DTO.DTOS.CategoryDTO;
using DTO.DTOS.ContactUsDTO;
using DTO.DTOS.DashboardDTO;
using DTO.DTOS.ProductDTO;
using DTO.DTOS.ReservationDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DashboardController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IContactUsService _contactUsService;
		private readonly IReservationService _reservationService;
		private readonly IMapper _mapper;

		public DashboardController(ICategoryService categoryService, IProductService productService, IContactUsService contactUsService, IReservationService reservationService, IMapper mapper)
		{
			_categoryService = categoryService;
			_productService = productService;
			_contactUsService = contactUsService;
			_reservationService = reservationService;
			_mapper = mapper;
		}

		[HttpGet("ItemCounts")]
		public IActionResult GetItemCounts()
		{
			var CategoryCount = (_mapper.Map<IEnumerable<ResultCategoryDTO>>(_categoryService.GetList())).Count();
			var ProductCount = (_mapper.Map<IEnumerable<ResultProductDTO>>(_productService.GetList())).Count();
			var MessageCount = (_mapper.Map<IEnumerable<ResultContactUsDTO>>(_contactUsService.GetList())).Count();
			var ReservationCount = (_mapper.Map<IEnumerable<ResultReservationDTO>>(_reservationService.GetList())).Count();
			ItemCountsDTO dto= new ItemCountsDTO();
			dto.ProductCount = ProductCount;
			dto.CategoryCount = CategoryCount;
			dto.ReservationCount = ReservationCount;
			dto.UnreadMessageCount = MessageCount;
			return Ok(dto);
		}
	}
}
