using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Question
{
    public class DetailModel : PageModel
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public DetailModel(
            IQuestionService questionService,
            IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        public Sporkocu.Domain.Entities.Question Question { get; set; }

        public Sporkocu.Domain.Entities.Answer Answer { get; set; }

        public bool IsOwner { get; set; }

        public IActionResult OnGet(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login/Index");
            }

            var questionResponse = _questionService.GetById(id);

            if (questionResponse.Error.HasException)
            {
                return BadRequest(questionResponse.Error.Message);
            }

            if (questionResponse.Entity == null)
            {
                return NotFound();
            }

            Question = questionResponse.Entity;

            IsOwner = Question.UserId == userId.Value;

            var answerResponse = _answerService.GetList();

            if (answerResponse.Error.HasException)
            {
                return BadRequest(answerResponse.Error.Message);
            }

            Answer = answerResponse.EntityList
                .FirstOrDefault(x => x.QuestionId == Question.Id);

            return Page();
        }
    }
}