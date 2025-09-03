using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Results.ReservationResult
{
    public class GetReservationQueryResult
    {
        public int ReservationId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public int CarId { get; set; }
        public Car CarType { get; set; }
    }
}
