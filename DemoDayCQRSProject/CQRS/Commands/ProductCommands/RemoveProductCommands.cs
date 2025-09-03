namespace DemoDayCQRSProject.CQRS.Commands.ProductCommands
{
    public class RemoveProductCommands
    {
        public int ProductId { get; set; }

        public RemoveProductCommands(int productId)
        {
            ProductId = productId;
        }
    }
}
