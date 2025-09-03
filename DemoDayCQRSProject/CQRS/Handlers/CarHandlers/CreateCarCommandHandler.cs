using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CarCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    { private readonly DemoContext _context;

        public CreateCarCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCarCommands command)
        {
            _context.Cars.Add(new Entities.Car
            {
              CarBrand = command.CarBrand,
                CarModel = command.CarModel,
                Gearbox = command.Gearbox,
                CarDoorCount = command.CarDoorCount,
                CarImmageUrl = command.CarImmageUrl,
                CarPrice = command.CarPrice,
                FuelType = command.FuelType,    
            });
            await _context.SaveChangesAsync();
        }   
    }
}
