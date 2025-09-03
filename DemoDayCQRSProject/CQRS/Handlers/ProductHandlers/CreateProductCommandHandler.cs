using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ProductCommands;
using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly DemoContext _context;

        public CreateProductCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateProductCommands command)
        {
            _context.Products.Add(new Product
            {
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductStock = command.ProductStock,
            });
            await _context.SaveChangesAsync();
        }

    }
}
