using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CategoryCommands;
using DemoDayCQRSProject.Entities;

namespace DemoDayCQRSProject.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly DemoContext _context;

        public CreateCategoryCommandHandler(DemoContext context)
        {
            _context = context;
        }



        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.CategoryName,
            });
            await _context.SaveChangesAsync();
        }



    }
}
