using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.ViewComponents.LayoutComponent
{
	public class AdminLayoutSideBarComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		} 
	}
}
