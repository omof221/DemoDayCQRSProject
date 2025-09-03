using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Commands.ReservationCommands
{
    public class CreateResevationCommands
    {
     
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public int CarId { get; set; }
        public Car CarType { get; set; }
    }
}
