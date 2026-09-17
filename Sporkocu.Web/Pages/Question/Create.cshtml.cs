using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Question
{
    public class CreateModel : PageModel
    {
        private readonly IQuestionService _questionService;

        public CreateModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Question Question { get; set; } = new();

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            ModelState.Remove("Question.Answers"); // answer şu an bu formdan gelmeyecek dahil etme demek

            if (!ModelState.IsValid) // kurallara uygun mu değil mi diye bakıyor
                return Page();

            Question.UserId = userId.Value;
            Question.Answers = new List<Sporkocu.Domain.Entities.Answer>();

            var response = _questionService.Add(new QuestionRequest
            {
                Entity = Question
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return RedirectToPage("/Question/List");
        }
    }
}