using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Areas.Admin.DTOS.CategoryDTO;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory	_http;
        public CategoryController(IHttpClientFactory http)
        {
            _http = http;
        }
		[HttpGet]
        public async Task<IActionResult> CategoryList()
		{
			var client=_http.CreateClient();
			var response = await client.GetAsync($"https://localhost:44391/api/Category/CategoryList");
			if (response.IsSuccessStatusCode)
			{
				var jsonData=await response.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<IEnumerable<CategoryListDTO>>(jsonData);
				return View(values);
			}
			else
			{
				return NotFound();
			}
			
		}
		[HttpGet]
		public IActionResult NewCategory()
		{
			NewCategoryDTO dto = new NewCategoryDTO();
			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> NewCategory(CategoryListDTO dto)
		{
			var client=_http.CreateClient();		
			var jsondata=JsonConvert.SerializeObject(dto);
			StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
			var response = await client.PostAsync($"https://localhost:44391/api/Category/Create",content);
			if (response.IsSuccessStatusCode)
			{


				return RedirectToAction("CategoryList");
			}
			else
			{
				return NotFound();
			}	
		}
		
		public async Task<IActionResult> UpdateCategory(int Id)
		{
			var client = _http.CreateClient();
			var response = await client.GetAsync($"https://localhost:44391/api/Category/GetById/{Id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDTO>(jsonData);			
			
				return View(values);
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO dto)
		{
			var client = _http.CreateClient();
			var jsondata= JsonConvert.SerializeObject(dto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var response = await client.PutAsync($"https://localhost:44391/api/Category/Update/", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("CategoryList");
			}
			return NotFound();
		}


		public async Task<IActionResult> DeleteCategory(int Id)
		{
			var client = _http.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:44391/api/Category/Delete/{Id}");
			if (response.IsSuccessStatusCode)
			{

				return RedirectToAction("CategoryList");
			}
			else
			{

				return NotFound();
			}
		}
	}
}
