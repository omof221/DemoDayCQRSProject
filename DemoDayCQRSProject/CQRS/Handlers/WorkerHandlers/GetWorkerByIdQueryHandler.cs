using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.WorkerQueries;
using DemoDayCQRSProject.CQRS.Results.WorkerResult;

namespace DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers
{
    public class GetWorkerByIdQueryHandler
    {
        private readonly DemoContext context;

        public GetWorkerByIdQueryHandler(DemoContext context)
        {
            this.context = context;
        }


        public async Task<GetWorkerByIdQueryResult> Handle(GetWorkerByIdQuery query)
        {
            var values = await context.Workers.FindAsync(query.WorkerId);
            return new GetWorkerByIdQueryResult
            {
                WorkerId = values.WorkerId,
                WorkerNameSurname = values.WorkerNameSurname,
            };
        }






    }
}
