using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.ReservationResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler
    {
        private readonly DemoContext context;

        public GetReservationQueryHandler(DemoContext context)
        {
            this.context = context;
        }
        //public async Task<List<GetReservationQueryResult>> Handler()
        //{
        //    var values = context.Reservations.ToList();
        //    return values.Select(x => new GetReservationQueryResult
        //    {
        //        ReservationId = x.ReservationId,
        //        PickUpDate = x.PickUpDate,
        //        DropOffDate = x.DropOffDate,
        //        PickUpLocation = x.PickUpLocation,
        //        DropOffLocation = x.DropOffLocation,
        //        CarId = x.CarId
        //    }).ToList();
        //}
        public async Task<List<GetReservationQueryResult>> Handler()
        {
            var values = await context.Reservations
                                      .Include(x => x.CarType) // Car bilgilerini de çek
                                      .ToListAsync();

            return values.Select(x => new GetReservationQueryResult
            {
                ReservationId = x.ReservationId,
                PickUpDate = x.PickUpDate,
                DropOffDate = x.DropOffDate,
                PickUpLocation = x.PickUpLocation,
                DropOffLocation = x.DropOffLocation,
                CarId = x.CarId,
                CarType = x.CarType   // burası dolu gelecek
            }).ToList();
        }
    }
}
