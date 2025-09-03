using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ReservationCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler
    { private readonly DemoContext _context;

        public CreateReservationCommandHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateResevationCommands command)
        { 
        _context.Reservations.Add(new Entities.Reservation
                {
            PickUpDate = command.PickUpDate,
            DropOffDate = command.DropOffDate,
            PickUpLocation = command.PickUpLocation,
            DropOffLocation = command.DropOffLocation,
            CarId = command.CarId,
            CarType = command.CarType,  
        });
            await _context.SaveChangesAsync();





        }





    }
}
