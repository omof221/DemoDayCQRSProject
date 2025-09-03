using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Results.WorkerResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers
{
    public class GetWorkerQueryHandler
    {
        private readonly DemoContext context;

        public GetWorkerQueryHandler(DemoContext context)
        {
            this.context = context;
        }

        public async Task<List<GetWorkerQueryResult>> Handle()
        {

            var values = context.Workers.ToListAsync();
            return (await values).Select(x => new GetWorkerQueryResult
            {
                WorkerId = x.WorkerId,
                WorkerNameSurname = x.WorkerNameSurname
            }).ToList();






        }




    }
}
