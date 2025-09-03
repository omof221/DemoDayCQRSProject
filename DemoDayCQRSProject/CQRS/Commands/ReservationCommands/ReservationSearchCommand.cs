namespace DemoDayCQRSProject.CQRS.Commands.ReservationCommands
{
    public class ReservationSearchCommand
    {
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
