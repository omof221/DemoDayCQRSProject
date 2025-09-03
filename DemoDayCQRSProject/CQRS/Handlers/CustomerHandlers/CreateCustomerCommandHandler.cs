using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CustomerCommands;
using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler
    {
        private readonly DemoContext _context;

        public CreateCustomerCommandHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            _context.Customers.Add(new Customer
            {
                CustomerCity = command.CustomerCity,
                CustomerName = command.CustomerName,
                CustomerSurname = command.CustomerSurname
            });

            await _context.SaveChangesAsync();
        }

    }
}
