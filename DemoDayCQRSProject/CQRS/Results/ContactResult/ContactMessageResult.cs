namespace DemoDayCQRSProject.CQRS.Results.ContactResult
{
    public class ContactMessageResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Project { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public string AiReplyPreview { get; set; }
        public DateTime? RepliedAt { get; set; }
    }
}
