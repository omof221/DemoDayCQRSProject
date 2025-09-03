using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Queries.ContactQueries;
using DemoDayCQRSProject.CQRS.Results.ContactResult;
using Microsoft.EntityFrameworkCore;

namespace DemoDayCQRSProject.CQRS.Handlers.ContactHandlers
{
    public class GetContactMessagesQueryHandler
    {
        private readonly DemoContext _context;

        public GetContactMessagesQueryHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ContactMessageResult>> HandleAsync(GetContactMessagesQuery q)
        {
            return await _context.ContactMessages
                .OrderByDescending(x => x.CreatedAt)
                .Skip((q.Page - 1) * q.PageSize)
                .Take(q.PageSize)
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
                })
                .ToListAsync();
        }




    }
}
