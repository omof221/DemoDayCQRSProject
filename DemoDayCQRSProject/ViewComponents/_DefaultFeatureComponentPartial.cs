using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
