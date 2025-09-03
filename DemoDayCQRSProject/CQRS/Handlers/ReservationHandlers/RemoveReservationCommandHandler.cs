using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ReservationCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class RemoveReservationCommandHandler
    {
        private readonly DemoContext context;

        public RemoveReservationCommandHandler(DemoContext context)
        {
            this.context = context;
        }



        public async Task Handle(RemoveReservationCommands command)
        {
            var values = await context.Reservations.FindAsync(command.ReservationId);
            context.Reservations.Remove(values);
            await context.SaveChangesAsync();
        }






    }
}
