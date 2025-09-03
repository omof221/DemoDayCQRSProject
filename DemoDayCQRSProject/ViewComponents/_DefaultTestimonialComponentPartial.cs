using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
