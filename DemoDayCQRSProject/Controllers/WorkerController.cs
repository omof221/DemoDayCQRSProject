using DemoDayCQRSProject.CQRS.Commands.WorkerCommands;
using DemoDayCQRSProject.CQRS.Handlers.WorkerHandlers;
using DemoDayCQRSProject.CQRS.Queries.WorkerQueries;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class WorkerController : Controller
    {private readonly GetWorkerQueryHandler _getWorkerQueryHandler;
        private readonly GetWorkerByIdQueryHandler _getWorkerByIdQueryHandler;
        private readonly CreateWorkerCommandHandler _createWorkerCommandHandler;
        private readonly UpdateWorkerCommandHandler _updateWorkerCommandHandler;
        private readonly RemoveWorkerCommandHandler _removeWorkerCommandHandler;

        public WorkerController(GetWorkerQueryHandler getWorkerQueryHandler, GetWorkerByIdQueryHandler getWorkerByIdQueryHandler, CreateWorkerCommandHandler createWorkerCommandHandler, UpdateWorkerCommandHandler updateWorkerCommandHandler, RemoveWorkerCommandHandler removeWorkerCommandHandler)
        {
            _getWorkerQueryHandler = getWorkerQueryHandler;
            _getWorkerByIdQueryHandler = getWorkerByIdQueryHandler;
            _createWorkerCommandHandler = createWorkerCommandHandler;
            _updateWorkerCommandHandler = updateWorkerCommandHandler;
            _removeWorkerCommandHandler = removeWorkerCommandHandler;
        }

        public async Task<IActionResult> WorkerList()
        { var value = await _getWorkerQueryHandler.Handle();

            return View(value);
        }
        [HttpGet]
        public IActionResult CreateWorker()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorker(CreateWorkerCommands commands)
        {
            await _createWorkerCommandHandler.Handle(commands);
            return RedirectToAction("WorkerList");
        }
        public async Task<IActionResult> DeleteWorker(int id)
        {
            await _removeWorkerCommandHandler.Handle(new RemoveWorkerCommands(id));
            return RedirectToAction("WorkerList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWorker(int id)
        {
            var value = await _getWorkerByIdQueryHandler.Handle(new GetWorkerByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWorker(UpdateWorkerCommands commands)
        {
            await _updateWorkerCommandHandler.Handle(commands);
            return RedirectToAction("WorkerList");
        }
    }
}
