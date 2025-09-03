namespace DemoDayCQRSProject.CQRS.Commands.WorkerCommands
{
    public class RemoveWorkerCommands
    {
        public int WorkerId { get; set; }

        public RemoveWorkerCommands(int workerId)
        {
            WorkerId = workerId;
        }
    }
}
