namespace DemoDayCQRSProject.CQRS.Commands.ContactCommands
{
    public class CreateContactMessageCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Project { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
