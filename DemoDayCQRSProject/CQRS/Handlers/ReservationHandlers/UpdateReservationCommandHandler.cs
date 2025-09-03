using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ReservationCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler
    {
        private readonly DemoContext context;

        public UpdateReservationCommandHandler(DemoContext context)
        {
            this.context = context;
        }


        public async Task Handle(UpdateReservationCommands commands)
        {
            var values= await context.Reservations.FindAsync(commands.ReservationId);
            values.PickUpDate = commands.PickUpDate;
            values.DropOffDate= commands.DropOffDate;   
            values.PickUpLocation = commands.PickUpLocation;    
            values.DropOffLocation = commands.DropOffLocation;  
            values.CarId = commands.CarId;
            values.CarType = commands.CarType;  
            await context.SaveChangesAsync();   
                
                
        }
    }
}
