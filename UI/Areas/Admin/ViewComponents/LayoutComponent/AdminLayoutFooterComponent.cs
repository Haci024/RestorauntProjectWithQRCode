using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.ViewComponents.LayoutComponent
{
    public class AdminLayoutFooterComponent : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {

            return View();
        }
    }

}
