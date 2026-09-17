using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Question
{
    public class UpdateModel : PageModel
    {
        private readonly IQuestionService _service;

        public UpdateModel(IQuestionService service)
        {
            _service = service;
        }

        [BindProperty]
        public Domain.Entities.Question Question { get; set; }

        public IActionResult OnGet(int id)
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");

            if (currentUserId == null)
                return RedirectToPage("/Login/Index");

            Question = _service.GetById(id).Entity;

            if (Question == null)
                return NotFound();

            if (Question.UserId != currentUserId.Value)
                return Forbid();

            return Page();
        }

        public IActionResult OnPost()
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");

            if (currentUserId == null)
                return RedirectToPage("/Login/Index");

            var question = _service.GetById(Question.Id).Entity;

            if (question == null)
                return NotFound();

            if (question.UserId != currentUserId.Value)
                return Forbid();

            question.Title = Question.Title;
            question.Description = Question.Description;

            _service.Update(new QuestionRequest
            {
                Entity = question
            });

            return RedirectToPage("List");
        }
    }
}