namespace DemoDayCQRSProject.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommands
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
