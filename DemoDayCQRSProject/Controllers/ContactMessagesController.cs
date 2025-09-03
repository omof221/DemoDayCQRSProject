using DemoDayCQRSProject.CQRS.Handlers.ContactHandlers;
using DemoDayCQRSProject.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class ContactMessagesController : Controller
    {
        private readonly GetContactMessagesQueryHandler _listHandler;
        private readonly GetContactMessageByIdQueryHandler _detailHandler;
        private readonly SetAiReplyForContactMessageCommandHandler _setReplyHandler;

        public ContactMessagesController(GetContactMessagesQueryHandler listHandler, GetContactMessageByIdQueryHandler detailHandler, SetAiReplyForContactMessageCommandHandler setReplyHandler)
        {
            _listHandler = listHandler;
            _detailHandler = detailHandler;
            _setReplyHandler = setReplyHandler;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 20, string? search = null)
        {
            // Basit filtre: server-side arama istersen query/handler'a ek alanlar açabilirsin.
            var items = await _listHandler.HandleAsync(new GetContactMessagesQuery
            {
                Page = page,
                PageSize = pageSize
            });

            if (!string.IsNullOrWhiteSpace(search))
                items = items.Where(x =>
                        (x.Name?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (x.Email?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (x.Subject?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false))
                    .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.Search = search;

            return View(items);
        }

        // /Admin/ContactMessages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _detailHandler.HandleAsync(new GetContactMessageByIdQuery(id));
            if (item == null) return NotFound();
            return View(item);
        }

        // İsteğe bağlı: okundu işareti
        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var item = await _detailHandler.HandleAsync(new GetContactMessageByIdQuery(id));
            if (item == null) return NotFound();

            await _setReplyHandler.HandleAsync(new CQRS.Commands.ContactCommands.SetAiReplyForContactMessageCommand
            {
                Id = item.Id,
                AiReplyPreview = item.AiReplyPreview, // dokunma
                RepliedAt = item.RepliedAt            // dokunma
            });
            // IsRead alanını da güncellemek istersen ayrı bir Command/Handler ekle.

            TempData["AdminInfo"] = "Mesaj okundu olarak işaretlendi (örnek).";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
