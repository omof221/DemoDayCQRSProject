using DemoDayCQRSProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class AıAsistantCar : Controller
    {
        private readonly CarAsistantService _carAsistantService;

        public AıAsistantCar(CarAsistantService carAsistantService)
        {
            _carAsistantService = carAsistantService;
        }
        [HttpGet]
        public IActionResult GetCarSuggestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCarSuggestion(string userInput)
        {
            var suggestion = await _carAsistantService.GetCarSuggestionAsync(userInput);
            return Json(new { suggestion });
        }
    }
}
