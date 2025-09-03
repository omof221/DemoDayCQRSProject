using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.CarQueries;
using DemoDayCQRSProject.CQRS.Results.CarResult;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetCarByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _context.Cars.FindAsync(query.CarId);
            return new GetCarByIdQueryResult
            {
                CarBrand = values.CarBrand,
                CarDoorCount = values.CarDoorCount,
                CarId = values.CarId,
                CarImmageUrl = values.CarImmageUrl,
                CarModel = values.CarModel,
                CarPrice = values.CarPrice,
                FuelType = values.FuelType,
                Gearbox = values.Gearbox
            };
        }
    }
}
