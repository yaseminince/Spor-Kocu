using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Question
{
    public class DeleteModel : PageModel
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public DeleteModel(
            IQuestionService questionService,
            IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        [BindProperty]
        public int Id { get; set; }

        public string? Mode { get; set; }

        public bool IsAdmin => Mode == "admin";

        public Domain.Entities.Question Question { get; set; }

        public IActionResult OnGet(int id, string? mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            Mode = mode;

            var questionResponse = _questionService.GetById(id);

            if (questionResponse.Error.HasException ||
                questionResponse.Entity == null)
            {
                return NotFound();
            }

            // Kullanıcıysa sadece kendi sorusunu silebilir
            if (!IsAdmin &&
                questionResponse.Entity.UserId != userId.Value)
            {
                return RedirectToPage("/Question/List");
            }

            // Kullanıcı tarafında cevaplanmış soru silinemez.
            // Admin cevaplanmış soruyu da silebilir.
            if (!IsAdmin)
            {
                var answerResponse = _answerService.GetList();

                if (answerResponse.Error.HasException)
                    return NotFound();

                var answer = answerResponse.EntityList
                    .FirstOrDefault(x => x.QuestionId == id);

                if (answer != null)
                {
                    return RedirectToPage("/Question/List");
                }
            }

            Id = id;
            Question = questionResponse.Entity;

            return Page();
        }

        public IActionResult OnPost(string? mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            Mode = mode;

            var questionResponse = _questionService.GetById(Id);

            if (questionResponse.Error.HasException ||
                questionResponse.Entity == null)
            {
                return NotFound();
            }

            // Kullanıcıysa sadece kendi sorusunu silebilir
            if (!IsAdmin &&
                questionResponse.Entity.UserId != userId.Value)
            {
                return RedirectToPage("/Question/List");
            }

            // Kullanıcı tarafında cevaplanmış soru silinemez.
            // Admin için bu kontrol yok.
            if (!IsAdmin)
            {
                var answerResponse = _answerService.GetList();

                if (answerResponse.Error.HasException)
                    return RedirectToPage("/Question/List");

                var answer = answerResponse.EntityList
                    .FirstOrDefault(x => x.QuestionId == Id);

                if (answer != null)
                    return RedirectToPage("/Question/List");
            }

            _questionService.Delete(
                new QuestionRequest
                {
                    Entity = questionResponse.Entity
                });

            if (IsAdmin)
            {
                return RedirectToPage(
                    "/Question/List",
                    new { mode = "admin" });
            }

            return RedirectToPage("/Question/List");
        }
    }
}