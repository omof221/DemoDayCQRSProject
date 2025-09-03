using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.CategoryQueries;
using DemoDayCQRSProject.CQRS.Results.CategoryResults;
using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.CategoryQueries;
using DemoDayCQRSProject.CQRS.Results.CategoryResults;

namespace DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetCategoryByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryName = values.CategoryName,
                CategoryId = values.CategoryId  
            };
        }

    }
}
