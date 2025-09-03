namespace DemoDayCQRSProject.CQRS.Commands.ProductCommands
{
    public class CreateProductCommands
    {
       
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
