using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Answer
{
    public class ListModel : PageModel
    {
        private readonly IAnswerService _answerService;

        public ListModel(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public List<Sporkocu.Domain.Entities.Answer> Answers { get; set; }
            = new List<Sporkocu.Domain.Entities.Answer>();

        public bool IsAdmin { get; set; }

        public IActionResult OnGet()
        {
            IsAdmin = Request.Query["mode"] == "admin";

            var userId = HttpContext.Session.GetInt32("UserId");

            if (!IsAdmin && userId == null)
                return RedirectToPage("/Login/Index");

            var response = _answerService.GetList();

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            Answers = response.EntityList;

            return Page();
        }
    }
}