using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.ViewComponents.LayoutComponent
{
    public class AdminLayoutHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
