using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultContactComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    } 
}
