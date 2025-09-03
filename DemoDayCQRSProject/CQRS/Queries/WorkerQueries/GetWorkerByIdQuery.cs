namespace DemoDayCQRSProject.CQRS.Queries.WorkerQueries
{
    public class GetWorkerByIdQuery
    {
        public int WorkerId { get; set; }

        public GetWorkerByIdQuery(int workerId)
        {
            WorkerId = workerId;
        }
    }
}
