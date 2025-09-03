namespace DemoDayCQRSProject.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }

        public string Name { get; set; }           // Your Name
        public string Email { get; set; }          // Your Email
        public string Phone { get; set; }          // Phone
        public string Project { get; set; }        // Your Project
        public string Subject { get; set; }        // Subject
        public string Body { get; set; }           // Message

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        // AI & Mail bilgileri
        public string AiReplyPreview { get; set; } // Kullanıcıya gönderilen AI cevabının özeti/metni
        public DateTime? RepliedAt { get; set; }
    }
}
