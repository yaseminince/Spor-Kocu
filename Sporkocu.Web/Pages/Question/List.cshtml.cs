using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Question
{
    public class ListModel : PageModel
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public ListModel(
            IQuestionService questionService,
            IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        public List<Sporkocu.Domain.Entities.Question> Questions { get; set; } = new();

        public List<Sporkocu.Domain.Entities.Answer> Answers { get; set; } = new();

        public bool IsAdmin => Request.Query["mode"] == "admin";

        public IActionResult OnGet()
        {
            var response = _questionService.GetList();

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            var answerResponse = _answerService.GetList();

            if (answerResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    answerResponse.Error.Message);

                return Page();
            }

            Answers = answerResponse.EntityList;

            if (IsAdmin)
            {
                Questions = response.EntityList;
            }
            else
            {
                var userId = HttpContext.Session.GetInt32("UserId");

                if (userId == null)
                    return RedirectToPage("/Login/Index");

                Questions = response.EntityList
                    .Where(x => x.UserId == userId.Value)
                    .ToList();
            }

            return Page();
        }
    }
}