using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CustomerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler
    {
        private readonly DemoContext _context;

        public UpdateCustomerCommandHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCustomerCommand command)
        {
            var values = await _context.Customers.FindAsync(command.CustomerId);

            if (values == null)
            {
                throw new Exception("Güncellenecek müşteri bulunamadı.");
            }

            values.CustomerName = command.CustomerName;
            values.CustomerSurname = command.CustomerSurname;
            values.CustomerCity = command.CustomerCity;

            await _context.SaveChangesAsync();
        }

    }
}
