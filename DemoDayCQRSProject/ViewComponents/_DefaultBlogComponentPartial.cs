using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
