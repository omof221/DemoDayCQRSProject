using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.ProductResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly DemoContext _context;

        public GetProductQueryHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _context.Products.ToListAsync();
            return values.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock
            }).ToList();
        }




    }
}
