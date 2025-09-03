using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CategoryCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    { private readonly DemoContext _context;

        public RemoveCategoryCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var values = await _context.Categories.FindAsync(command.CategoryId);
            _context.Categories.Remove(values);
            await _context.SaveChangesAsync();
        }

    }
}
