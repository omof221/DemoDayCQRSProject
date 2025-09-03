using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.ReservationQueries;
using DemoDayCQRSProject.CQRS.Results.ReservationResult;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetReservationByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery query)
        {
            var values = await _context.Reservations.FindAsync(query.ReservationId);
            return new GetReservationByIdQueryResult
            {
                ReservationId = values.ReservationId,
                PickUpDate = values.PickUpDate,
                DropOffDate = values.DropOffDate,
                PickUpLocation = values.PickUpLocation,
                DropOffLocation = values.DropOffLocation,
                CarId = values.CarId,
                CarType = values.CarType
            };
        }




    }
}
