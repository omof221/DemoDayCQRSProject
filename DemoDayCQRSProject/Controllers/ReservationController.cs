using DemoDayCQRSProject.CQRS.Commands.ReservationCommands;
using DemoDayCQRSProject.CQRS.Handlers.CarHandlers;
using DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers;
using DemoDayCQRSProject.CQRS.Queries.ReservationQueries;
using DemoDayCQRSProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoDayCQRSProject.Controllers
{
    public class ReservationController : Controller
    { private readonly GetReservationQueryHandler _getReservationQueryHandler;
        private readonly GetReservationByIdQueryHandler _getReservationByIdQueryHandler;
        private readonly CreateReservationCommandHandler _createReservationCommandHandler;
        private readonly UpdateReservationCommandHandler _updateReservationCommandHandler;
        private readonly RemoveReservationCommandHandler _removeReservationCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly SearchAvailableCarsHandler _searchAvailableCarsHandler;
        public ReservationController(GetReservationQueryHandler getReservationQueryHandler, GetReservationByIdQueryHandler getReservationByIdQueryHandler, CreateReservationCommandHandler createReservationCommandHandler, UpdateReservationCommandHandler updateReservationCommandHandler, RemoveReservationCommandHandler removeReservationCommandHandler, GetCarQueryHandler getCarQueryHandler, SearchAvailableCarsHandler searchAvailableCarsHandler)
        {
            _getReservationQueryHandler = getReservationQueryHandler;
            _getReservationByIdQueryHandler = getReservationByIdQueryHandler;
            _createReservationCommandHandler = createReservationCommandHandler;
            _updateReservationCommandHandler = updateReservationCommandHandler;
            _removeReservationCommandHandler = removeReservationCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _searchAvailableCarsHandler = searchAvailableCarsHandler;
        }

        public async Task<IActionResult> ReservationList()
        { var values= await _getReservationQueryHandler.Handler();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateReservation()
        {
            var cars = await _getCarQueryHandler.Handler();

            // ViewBag ile dropdown için hazırlanıyor
            ViewBag.Cars = cars.Select(c => new SelectListItem
            {
                Value = c.CarId.ToString(),
                Text = $"{c.CarBrand} {c.CarModel}"
            }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateResevationCommands commands)
        {
            await _createReservationCommandHandler.Handle(commands);
            return RedirectToAction("ReservationList");
        }
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _removeReservationCommandHandler.Handle(new RemoveReservationCommands(id));
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            //var value = await _getReservationByIdQueryHandler.Handle(new GetReservationByIdQuery(id));
            //return View(value);
            var reservation = await _getReservationByIdQueryHandler.Handle(new GetReservationByIdQuery(id));

            // Cars listesini dropdown için doldur
            var cars = await _getCarQueryHandler.Handler();
            ViewBag.Cars = cars.Select(c => new SelectListItem
            {
                Value = c.CarId.ToString(),
                Text = c.CarBrand + " " + c.CarModel
            }).ToList();

            return View(new UpdateReservationCommands
            {
                ReservationId = reservation.ReservationId,
                PickUpDate = reservation.PickUpDate,
                DropOffDate = reservation.DropOffDate,
                PickUpLocation = reservation.PickUpLocation,
                DropOffLocation = reservation.DropOffLocation,
                CarId = reservation.CarId
            });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommands commands)
        {
            await _updateReservationCommandHandler.Handle(commands);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> SearchLocation(string query, [FromServices] GooglePlacesService googlePlacesService)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query boş olamaz.");

            var result = await googlePlacesService.FindPlaceFromTextAsync(query);
            return Content(result, "application/json");
        }


        [HttpGet]
        public IActionResult SearchAvailableCars()
        {
            return View();
        }

        // Form post edilince çalışacak
        [HttpPost]
        public async Task<IActionResult> SearchAvailableCars(ReservationSearchCommand command)
        {
            var cars = await _searchAvailableCarsHandler.Handle(command);

            if (!cars.Any())
                ViewBag.Message = "Seçilen tarihlerde uygun araç bulunamadı.";

            return View("AvailableCars", cars);
        }

    }
}
