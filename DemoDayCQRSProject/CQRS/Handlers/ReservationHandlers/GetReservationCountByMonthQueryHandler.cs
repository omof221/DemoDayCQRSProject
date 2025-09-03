using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.ReservationQueries;
using DemoDayCQRSProject.CQRS.Results.ReservationResult;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationCountByMonthQueryHandler
    {
        private readonly DemoContext _context;

        public GetReservationCountByMonthQueryHandler(DemoContext context)
        {
            _context = context;
        }
        public GetReservationCountByMonthResult Handle(GetReservationCountByMonthQuery query)
        {
            var count = _context.Reservations
                .Where(r => r.PickUpDate.Year == query.Year && r.PickUpDate.Month == query.Month)
                .Count();

            return new GetReservationCountByMonthResult
            {
                Count = count
            };
        }
    }
}
