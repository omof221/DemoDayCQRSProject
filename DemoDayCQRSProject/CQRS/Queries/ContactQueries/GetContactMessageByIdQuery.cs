namespace DemoDayCQRSProject.CQRS.Queries.ContactQueries
{
    public class GetContactMessageByIdQuery
    {
        public int Id { get; set; }
        public GetContactMessageByIdQuery(int id) => Id = id;
    }
}
