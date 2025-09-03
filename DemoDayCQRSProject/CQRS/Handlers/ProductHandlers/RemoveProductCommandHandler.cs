using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ProductCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly DemoContext _context;

        public RemoveProductCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveProductCommands command)
        {
            var value = await _context.Products.FindAsync(command.ProductId);
            _context.Products.Remove(value);
            await _context.SaveChangesAsync();
        }

    }
}
