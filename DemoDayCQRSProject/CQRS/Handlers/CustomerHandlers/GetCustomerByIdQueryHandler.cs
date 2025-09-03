using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.CustomerQueries;
using DemoDayCQRSProject.CQRS.Results.CustomerResult;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetCustomerByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var values = await _context.Customers.FindAsync(query.CustomerId);

            return new GetCustomerByIdQueryResult
            {
                CustomerCity = values.CustomerCity,
                CustomerId = values.CustomerId,
                CustomerSurname = values.CustomerSurname,
                CustomerName = values.CustomerName
            };
        }






    }
}
