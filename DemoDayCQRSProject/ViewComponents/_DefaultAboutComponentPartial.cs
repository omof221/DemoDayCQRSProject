using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultAboutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
