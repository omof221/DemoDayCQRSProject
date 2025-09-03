using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.ProductQueries;
using DemoDayCQRSProject.CQRS.Results.ProductResult;

namespace DemoDayCQRSProject.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetProductByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var values = await _context.Products.FindAsync(query.ProductId);
            return new GetProductByIdQueryResult
            {
                ProductId = values.ProductId,
                ProductStock = values.ProductStock,
                ProductPrice = values.ProductPrice,
                ProductName = values.ProductName
            };
        }









    }
}
