using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.WorkerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers
{
    public class UpdateWorkerCommandHandler
    {
        private readonly DemoContext context;

        public UpdateWorkerCommandHandler(DemoContext context)
        {
            this.context = context;
        }
        public async Task Handle(UpdateWorkerCommands command)
        {
            var values = await context.Workers.FindAsync(command.WorkerId);
            values.WorkerNameSurname = command.WorkerNameSurname;

            await context.SaveChangesAsync();
        }




    }
}
