using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.WorkerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers
{
    public class CreateWorkerCommandHandler
    {
        private readonly DemoContext context;

        public CreateWorkerCommandHandler(DemoContext context)
        {
            this.context = context;
        }






        public async Task Handle(CreateWorkerCommands command)
        {
            context.Workers.Add(new Entities.Worker
            {
          
                WorkerNameSurname = command.WorkerNameSurname,
            });
            await context.SaveChangesAsync();
        }   
    }
}
