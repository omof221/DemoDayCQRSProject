namespace DemoDayCQRSProject.CQRS.Commands.CarCommands
{
    public class RemoveCarCommands
    {
        public int CarId { get; set; }

        public RemoveCarCommands(int carId)
        {
            CarId = carId;
        }
    }
}
