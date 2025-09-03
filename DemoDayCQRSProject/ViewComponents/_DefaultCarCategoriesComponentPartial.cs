using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Handlers.CarHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.ViewComponents
{
    public class _DefaultCarCategoriesComponentPartial : ViewComponent
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;

        public _DefaultCarCategoriesComponentPartial(GetCarQueryHandler getCarQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _getCarQueryHandler.Handler();
           
            return View(values);    
        }
    }
}
