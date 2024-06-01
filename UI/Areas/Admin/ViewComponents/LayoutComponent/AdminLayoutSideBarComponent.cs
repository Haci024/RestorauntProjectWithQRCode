using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.Admin.DTOS.CategoryDTO;
using UI.Areas.Admin.DTOS.DashboardDTO;

namespace UI.Areas.Admin.ViewComponents.LayoutComponent
{
	public class AdminLayoutSideBarComponent:ViewComponent
	{
		private readonly IHttpClientFactory _http;
        public AdminLayoutSideBarComponent(IHttpClientFactory factory)
        {
            _http = factory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _http.CreateClient();
			var response = await client.GetAsync($"https://localhost:44391/api/Dashboard/ItemCounts");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ItemCountsDTO>(jsonData);
				
			
				return View(values);
			}
			return View();
		} 
	}
}
