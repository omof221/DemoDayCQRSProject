using DemoDayCQRSProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class LocationController : Controller
    { private readonly GooglePlacesService _placesService;

        public LocationController(GooglePlacesService placesService)
        {
            _placesService = placesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new { candidates = new string[0] });

            var result = await _placesService.FindPlaceFromTextAsync(query);

            // JSON string döner → Content olarak direkt veriyoruz
            return Content(result, "application/json");
        }
    }
}
