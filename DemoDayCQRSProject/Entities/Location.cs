namespace DemoDayCQRSProject.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public string AirportCode { get; set; } // IATA kodu olabilir
    }
}
