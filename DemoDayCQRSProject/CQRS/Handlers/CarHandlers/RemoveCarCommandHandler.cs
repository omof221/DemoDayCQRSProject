using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CarCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly DemoContext _context;

        public RemoveCarCommandHandler(DemoContext context)
        {
            _context = context;
        }


        public async Task Handle(RemoveCarCommands command)
        {
            var values = await _context.Cars.FindAsync(command.CarId);
            _context.Cars.Remove(values);
            await _context.SaveChangesAsync();
        }   
    }
}
