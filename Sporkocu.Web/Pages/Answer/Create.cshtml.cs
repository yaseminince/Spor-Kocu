using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Answer
{
    public class CreateModel : PageModel
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public CreateModel(
            IAnswerService answerService,
            IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Answer Answer { get; set; } = new();

        public Sporkocu.Domain.Entities.Question Question { get; set; } = new();

        public IActionResult OnGet(int questionId)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var questionResponse = _questionService.GetById(questionId);

            if (questionResponse.Error.HasException)
                return BadRequest(questionResponse.Error.Message);

            if (questionResponse.Entity == null)
                return NotFound();

            Question = questionResponse.Entity;

            Answer.QuestionId = questionId;

            return Page();
        }

        public IActionResult OnPost(int questionId)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var questionResponse = _questionService.GetById(questionId);

            if (questionResponse.Error.HasException)
                return BadRequest(questionResponse.Error.Message);

            if (questionResponse.Entity == null)
                return NotFound();

            Question = questionResponse.Entity;

            ModelState.Remove("Answer.Question");
            ModelState.Remove("Answer.User");
            ModelState.Remove("Answer.Step");

            if (!ModelState.IsValid)
                return Page();

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Cevap verecek kullanıcı bilgisi bulunamadı.");

                return Page();
            }

            Answer.QuestionId = questionId;
            Answer.UserId = userId.Value;
            Answer.Step = 1;

            var response = _answerService.Add(new AnswerRequest
            {
                Entity = Answer
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return Redirect("/Question/List?mode=admin");
        }
    }
}