namespace DemoDayCQRSProject.CQRS.Commands.ContactCommands
{
    public class SetAiReplyForContactMessageCommand
    {
        public int Id { get; set; }
        public string AiReplyPreview { get; set; }
        public DateTime? RepliedAt { get; set; }
    }
}
