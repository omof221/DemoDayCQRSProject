using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.ContactCommands;
using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Handlers.ContactHandlers
{
    public class CreateContactMessageCommandHandler
    {
        private readonly DemoContext _context;

        public CreateContactMessageCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task<int> HandleAsync(CreateContactMessageCommand cmd)
        {
            var entity = new ContactMessage
            {
                Name = cmd.Name,
                Email = cmd.Email,
                Phone = cmd.Phone,
                Project = cmd.Project,
                Subject = cmd.Subject,
                Body = cmd.Body
            };
            _context.ContactMessages.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id; // admin tarafında göstersin diye Id dönüyoruz
        }
    }
}
