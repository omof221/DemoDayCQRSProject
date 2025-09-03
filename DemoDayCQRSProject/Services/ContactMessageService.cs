using DemoDayCQRSProject.CQRS.Commands.ContactCommands;
using DemoDayCQRSProject.CQRS.Handlers.ContactHandlers;
using DemoDayCQRSProject.CQRS.Results.ContactResult;

namespace DemoDayCQRSProject.Services
{
    public class ContactMessageService
    {
        private readonly RapidAiService _ai;
        private readonly MailService _mail;
        private readonly SetAiReplyForContactMessageCommandHandler _setAiReplyHandler;

        public ContactMessageService(RapidAiService ai, MailService mail, SetAiReplyForContactMessageCommandHandler setAiReplyHandler)
        {
            _ai = ai;
            _mail = mail;
            _setAiReplyHandler = setAiReplyHandler;
        }

        public async Task ProcessAndReplyAsync(ContactMessageResult message)
        {
            // 1) RapidAPI'den cevap üret
            var aiReply = await _ai.GenerateReplyAsync(message.Body);

            // 2) DB'ye kaydet
            await _setAiReplyHandler.HandleAsync(new SetAiReplyForContactMessageCommand
            {
                Id = message.Id,
                AiReplyPreview = aiReply,
                RepliedAt = DateTime.UtcNow
            });

            // 3) Mail gönder
            await _mail.SendEmailAsync(message.Email, $"Re: {message.Subject}", aiReply);
        }




    }
}
