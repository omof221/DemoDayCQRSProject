using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.CarResult;
using DemoDayCQRSProject.CQRS.Results.CategoryResults;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly DemoContext _context;

        public GetCarQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handler()
        {
            var values = await _context.Cars.ToListAsync();
            return values.Select(x => new GetCarQueryResult
            {CarId= x.CarId,
                CarBrand = x.CarBrand,
                CarModel = x.CarModel,
                Gearbox = x.Gearbox,
                CarDoorCount = x.CarDoorCount,
                CarImmageUrl = x.CarImmageUrl,
                CarPrice = x.CarPrice,
                FuelType = x.FuelType   

            }).ToList();


        }






    }
}
