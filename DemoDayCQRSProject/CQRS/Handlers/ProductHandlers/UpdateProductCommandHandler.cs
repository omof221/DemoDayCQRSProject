using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ProductCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {private readonly DemoContext _context;

        public UpdateProductCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateProductCommands command)
        {
            var values = await _context.Products.FindAsync(command.ProductId);
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductStock = command.ProductStock;
            await _context.SaveChangesAsync();
        }


    }
}
