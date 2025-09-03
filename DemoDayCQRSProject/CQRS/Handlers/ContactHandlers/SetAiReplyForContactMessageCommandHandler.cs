using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ContactCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.ContactHandlers
{
    public class SetAiReplyForContactMessageCommandHandler
    {
        private readonly DemoContext _context;

        public SetAiReplyForContactMessageCommandHandler(DemoContext context)
        {
            _context = context;
        }



        public async Task HandleAsync(SetAiReplyForContactMessageCommand cmd)
        {
            var entity = await _context.ContactMessages.FindAsync(cmd.Id);
            if (entity == null) return;

            entity.AiReplyPreview = cmd.AiReplyPreview;
            entity.RepliedAt = cmd.RepliedAt;
            await _context.SaveChangesAsync();
        }




    }
}
