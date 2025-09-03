using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ReservationCommands;
using DemoDayCQRSProject.CQRS.Results.CarResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class SearchAvailableCarsHandler
    {
        private readonly DemoContext _context;

        public SearchAvailableCarsHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<List<GetCarQueryResult>> Handle(ReservationSearchCommand command)
        {
            // Seçilen tarihlerde rezerve edilmiş araçları bul
            var reservedCarIds = await _context.Reservations
                .Where(r =>
                    (command.PickUpDate < r.DropOffDate && command.DropOffDate > r.PickUpDate) &&
                    (r.PickUpLocation == command.PickUpLocation || r.DropOffLocation == command.DropOffLocation))
                .Select(r => r.CarId)
                .ToListAsync();

            // Rezerve edilmeyen araçları getir
            var availableCars = await _context.Cars
                .Where(c => !reservedCarIds.Contains(c.CarId))
                .Select(c => new GetCarQueryResult
                {
                    CarId = c.CarId,
                    CarBrand = c.CarBrand,
                    CarModel = c.CarModel,
                    Gearbox = c.Gearbox,
                    CarDoorCount = c.CarDoorCount,
                    CarPrice = c.CarPrice,
                    FuelType = c.FuelType,
                    CarImmageUrl = c.CarImmageUrl
                })
                .ToListAsync();

            return availableCars;
        }
    }
}
