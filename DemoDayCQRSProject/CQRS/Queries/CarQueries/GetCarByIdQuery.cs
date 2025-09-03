namespace DemoDayCQRSProject.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public int CarId { get; set; }

        public GetCarByIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
