using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.CustomerResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler
    {


        private readonly DemoContext _context;

        public GetCustomerQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task<List<GetCustomerQueryResult>> Handle()
        {
            var values = await _context.Customers.ToListAsync();

            return values.Select(x => new GetCustomerQueryResult
            {
                CustomerCity = x.CustomerCity,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerSurname = x.CustomerSurname
            }).ToList();
        }
















    }
}
