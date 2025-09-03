using DemoDayCQRSProject.CQRS.Commands.ContactCommands;
using DemoDayCQRSProject.CQRS.Handlers.ContactHandlers;
using DemoDayCQRSProject.CQRS.Queries.ContactQueries;
using DemoDayCQRSProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoDayCQRSProject.Controllers
{
    public class ContactFormDto
    {
        [Required, StringLength(120)] public string Name { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [StringLength(30)] public string? Phone { get; set; }
        [StringLength(120)] public string? Project { get; set; }
        [Required, StringLength(160)] public string Subject { get; set; }
        [Required, StringLength(4000)] public string Body { get; set; }
    }
    public class ContactController : Controller
    {
        private readonly CreateContactMessageCommandHandler _create;
        private readonly GetContactMessageByIdQueryHandler _getById;
        private readonly Services.ContactMessageService _contactMessageService; // AI + Mail orkestrasyonu burada

        public ContactController(CreateContactMessageCommandHandler create, GetContactMessageByIdQueryHandler getById, ContactMessageService contactMessageService)
        {
            _create = create;
            _getById = getById;
            _contactMessageService = contactMessageService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendAjax(ContactFormDto dto)
        {
            if (!ModelState.IsValid)
            {
                // basit modelstate hata mesajı
                var firstError = string.Join(" ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = string.IsNullOrWhiteSpace(firstError) ? "Lütfen zorunlu alanları doldurun." : firstError });
            }

            try
            {
                // 1) Mesajı kaydet
                var id = await _create.HandleAsync(new CreateContactMessageCommand
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Project = dto.Project,
                    Subject = dto.Subject,
                    Body = dto.Body
                });

                // 2) DB’den mesajı oku (Result tipinde lazım)
                var msgResult = await _getById.HandleAsync(new GetContactMessageByIdQuery(id));
                if (msgResult == null)
                    return Json(new { success = false, message = "Mesaj kaydı bulunamadı." });

                // 3) AI cevabı üret + DB’ye yaz + Mail gönder
                await _contactMessageService.ProcessAndReplyAsync(msgResult);

                return Json(new
                {
                    success = true,
                    message = "Mesajınız başarıyla gönderildi. Yanıt e-postanıza iletildi."
                });
            }
            catch (Exception ex)
            {
                // Prod’da logla (ILogger)
                return Json(new
                {
                    success = false,
                    message = "Mesaj gönderilirken hata oluştu. " + ex.Message
                });
            }
        }
    }
}
