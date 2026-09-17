using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Answer
{
    public class DeleteModel : PageModel
    {
        private readonly IAnswerService _answerService;

        public DeleteModel(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Answer Answer { get; set; }

        public IActionResult OnGet(int id, string mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login/Index");
            }

            if (mode != "admin")
            {
                return Forbid();
            }

            var response = _answerService.GetById(id);

            if (response.Error.HasException)
            {
                return BadRequest(response.Error.Message);
            }

            if (response.Entity == null)
            {
                return NotFound();
            }

            Answer = response.Entity;

            return Page();
        }

        public IActionResult OnPost(int id, string mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login/Index");
            }

            if (mode != "admin")
            {
                return Forbid();
            }

            var response = _answerService.GetById(id);

            if (response.Entity == null)
            {
                return NotFound();
            }

            _answerService.Delete(
                new AnswerRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage(
                "/Answer/List",
                new { mode = "admin" });
        }
    }
}