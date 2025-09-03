namespace DemoDayCQRSProject.CQRS.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery
    {
        public int CustomerId { get; set; }

        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
