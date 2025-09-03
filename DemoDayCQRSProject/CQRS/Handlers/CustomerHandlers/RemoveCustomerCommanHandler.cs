using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CustomerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommanHandler
    {
        private readonly DemoContext _context;

        public RemoveCustomerCommanHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCustomerCommand command)
        {
            var values = await _context.Customers.FindAsync(command.CustomerId);

            if (values == null)
            {
                throw new Exception("Silinecek müşteri bulunamadı.");
            }

            _context.Customers.Remove(values);
            await _context.SaveChangesAsync();
        }

    }
}
