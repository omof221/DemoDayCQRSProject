using DemoDayCQRSProject.CQRS.Handlers.CarHandlers;
using DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers;
using DemoDayCQRSProject.CQRS.Queries.CarQueries;
using DemoDayCQRSProject.CQRS.Queries.ReservationQueries;
using DemoDayCQRSProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class AdminController : Controller
    { private readonly FuelPriceService _fuelPriceService;
        private readonly GetCarCountQueryHandler _getCarCountQueryHandler;
        private readonly GetReservationCountByMonthQueryHandler _getReservationCountByMonthQueryHandler;
        public AdminController(FuelPriceService fuelPriceService, GetCarCountQueryHandler getCarCountQueryHandler, GetReservationCountByMonthQueryHandler getReservationCountByMonthQueryHandler)
        {
            _fuelPriceService = fuelPriceService;
            _getCarCountQueryHandler = getCarCountQueryHandler;
            _getReservationCountByMonthQueryHandler = getReservationCountByMonthQueryHandler;
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }
        public async Task<IActionResult> Index(string city = "MUGLA")
        {
            var json = await _fuelPriceService.GetFuelPricesAsync(city);

            // data içindeki ilk ilçeyi al
            var firstDistrict = json["data"]?.First?.First;
            if (firstDistrict != null)
            {
                ViewBag.Benzin = firstDistrict["Kursunsuz_95(Excellium95)_TL/lt"]?.ToString();
                ViewBag.Motorin = firstDistrict["Motorin(Eurodiesel)_TL/lt"]?.ToString();
                ViewBag.MotorinEx = firstDistrict["Motorin(Excellium_Eurodiesel)_TL/lt"]?.ToString();
                ViewBag.Lpg = firstDistrict["Otogaz_TL_lt"]?.ToString();
                ViewBag.GazYagi = firstDistrict["Gazyağı_TL/lt"]?.ToString();
                ViewBag.Tarih=DateTime.Now.ToShortDateString();
            }
            var result = _getCarCountQueryHandler.Handle(new GetCarCountQuery());
            ViewBag.CarCount = result.Count;



            var now = DateTime.Now;
            var resultt = _getReservationCountByMonthQueryHandler.Handle(
                new GetReservationCountByMonthQuery(now.Year, now.Month));

            ViewBag.ReservationCountThisMonth = resultt.Count;







            return View();
        }
    }
}
