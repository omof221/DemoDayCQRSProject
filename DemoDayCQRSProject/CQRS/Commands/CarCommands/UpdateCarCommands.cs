namespace DemoDayCQRSProject.CQRS.Commands.CarCommands
{
    public class UpdateCarCommands
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string Gearbox { get; set; }
        public int CarDoorCount { get; set; }
        public string CarImmageUrl { get; set; }
        public int CarPrice { get; set; }
        public string FuelType { get; set; }
    }
}
