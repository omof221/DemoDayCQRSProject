using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.WorkerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers
{
    public class RemoveWorkerCommandHandler
    {private readonly DemoContext _context;
        public RemoveWorkerCommandHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveWorkerCommands command)
        {
            var values = await _context.Workers.FindAsync(command.WorkerId);
            _context.Workers.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
