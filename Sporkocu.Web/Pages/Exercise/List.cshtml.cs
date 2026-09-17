using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Exercise
{
    public class ListModel : PageModel
    {
        private readonly IExerciseService _exerciseService;

        public ListModel(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public List<Sporkocu.Domain.Entities.Exercise> Exercises { get; set; }
            = new List<Sporkocu.Domain.Entities.Exercise>();

        public bool IsAdmin { get; set; }

        public IActionResult OnGet()
        {
            IsAdmin = Request.Query["mode"] == "admin";

            var userId = HttpContext.Session.GetInt32("UserId");

            // Normal kullanıcı için login kontrolü
            if (!IsAdmin && userId == null)
                return RedirectToPage("/Login/Index");

            var response = _exerciseService.GetList();

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            Exercises = response.EntityList;

            return Page();
        }
    }
}