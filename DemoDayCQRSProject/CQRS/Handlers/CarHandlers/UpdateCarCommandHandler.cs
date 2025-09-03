using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CarCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    { private readonly DemoContext _context;

        public UpdateCarCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCarCommands command)
        {
            var values = await _context.Cars.FindAsync(command.CarId);
            values.CarBrand = command.CarBrand;
            values.CarModel = command.CarModel;
            values.Gearbox = command.Gearbox;
            values.CarDoorCount = command.CarDoorCount;
            values.CarImmageUrl = command.CarImmageUrl;
            values.CarPrice = command.CarPrice;
            values.FuelType = command.FuelType;

            await _context.SaveChangesAsync();
        }
    }
}
