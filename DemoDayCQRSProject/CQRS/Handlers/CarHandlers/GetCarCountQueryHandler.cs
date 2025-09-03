using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.CarQueries;
using DemoDayCQRSProject.CQRS.Results.CarResult;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class GetCarCountQueryHandler
    {
        private readonly DemoContext _context;

        public GetCarCountQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public GetCarCountResult Handle(GetCarCountQuery query)
        {
            var count = _context.Cars.Count();
            return new GetCarCountResult
            {
                Count = count
            };
        }






    }
}
