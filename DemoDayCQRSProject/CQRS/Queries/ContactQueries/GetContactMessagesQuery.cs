namespace DemoDayCQRSProject.CQRS.Queries.ContactQueries
{
    public class GetContactMessagesQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
