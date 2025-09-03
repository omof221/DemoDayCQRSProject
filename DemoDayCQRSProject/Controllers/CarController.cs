using DemoDayCQRSProject.CQRS.Commands.CarCommands;
using DemoDayCQRSProject.CQRS.Commands.CategoryCommands;
using DemoDayCQRSProject.CQRS.Handlers.CarHandlers;
using DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers;
using DemoDayCQRSProject.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class CarController : Controller
    { private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;

        public CarController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
        }

        public async Task<IActionResult> CarList()
        { var values = await _getCarQueryHandler.Handler(); 
            return View(values);
        }
        public async Task<IActionResult> AvaliablaCars()
        {
            var values = await _getCarQueryHandler.Handler();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommands commands)
        {

            await _createCarCommandHandler.Handle(commands);
            return RedirectToAction("CarList");

        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommands(id));
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommands commands)
        {
            await _updateCarCommandHandler.Handle(commands);
            return RedirectToAction("CarList");
        }   
    }
}
