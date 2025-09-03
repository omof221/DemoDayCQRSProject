namespace DemoDayCQRSProject.CQRS.Commands.CustomerCommands
{
    public class CreateCustomerCommand
    {
        
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
    }
}
