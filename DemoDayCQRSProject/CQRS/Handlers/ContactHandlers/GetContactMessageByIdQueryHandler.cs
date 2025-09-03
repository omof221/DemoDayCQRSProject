using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.ContactQueries;
using DemoDayCQRSProject.CQRS.Results.ContactResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.ContactHandlers
{
    public class GetContactMessageByIdQueryHandler
    {
        private readonly DemoContext _context;

        public GetContactMessageByIdQueryHandler(DemoContext context)
        {
            _context = context;
        }



        public async Task<ContactMessageResult> HandleAsync(GetContactMessageByIdQuery q)
        {
            return await _context.ContactMessages
                .Where(x => x.Id == q.Id)
                .Select(x => new ContactMessageResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Project = x.Project,
                    Subject = x.Subject,
                    Body = x.Body,
                    CreatedAt = x.CreatedAt,
                    IsRead = x.IsRead,
                    AiReplyPreview = x.AiReplyPreview,
                    RepliedAt = x.RepliedAt
                }).FirstOrDefaultAsync();
        }





    }
}
