namespace DemoDayCQRSProject.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    { // sorguda  kullanılacak parametreler burda tutulur
        public int CategoryId { get; set; }

        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
