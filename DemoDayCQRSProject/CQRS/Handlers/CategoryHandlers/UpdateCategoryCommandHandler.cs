using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CategoryCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly DemoContext _context;

        public UpdateCategoryCommandHandler(DemoContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _context.Categories.FindAsync(command.CategoryId);
            values.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();
        }

    }
}
