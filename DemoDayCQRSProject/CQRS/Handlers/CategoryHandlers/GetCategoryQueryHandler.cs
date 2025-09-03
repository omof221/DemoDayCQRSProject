using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.CategoryResults;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    { private readonly DemoContext _context;

        public GetCategoryQueryHandler(DemoContext context)
        {
            _context = context;
        }


        public async Task<List<GetCategoryQueryResult>> Handler()
        {
           var values = await _context.Categories.ToListAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();


        }
    }
}
