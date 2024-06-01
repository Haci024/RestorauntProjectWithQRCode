
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Areas.Admin.DTOS.ProductDTO;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _http;
        public ProductController(IHttpClientFactory client)
        {

            _http = client;

        }
        [HttpGet]
        public async  Task<IActionResult> ProductList()
        {
            var client = _http.CreateClient();
            var response = await client.GetAsync($"https://localhost:44391/api/Product/List");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ProductListDTO>>(jsonData);
                return View(values);
            }
            return View();
          
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int Id)
        {
            var client= _http.CreateClient();
            var response = await client.GetAsync($"https://localhost:44391/api/Product/GetById/{Id}");
           
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<GetProductDTO>(jsonData);
               
                return View(values);
            }
            else
            {

                return NotFound();
            }
          
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
          AddProductDTO dto=new AddProductDTO();

            return View(dto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductDTO dto)
        {
            var client=_http.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:44391/api/Product/Create", content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("ProductList");
            }
            else
            {
              
                
                return View();
            } 
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int Id)
        {
			var client = _http.CreateClient();
			var response = await client.GetAsync($"https://localhost:44391/api/Product/GetById/{Id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDTO>(jsonData);

				return View(values);
			}
            else
            {

                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dto)
        {


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var client= _http.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44391/api/Product/Delete/{Id}");
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("ProductList");
			}
            else
            {
                return NotFound();  
            }
          
        }
    }
}
