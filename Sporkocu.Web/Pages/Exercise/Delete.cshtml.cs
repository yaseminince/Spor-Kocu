using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Exercise
{
    public class DeleteModel : PageModel
    {
        private readonly IExerciseService _exerciseService;

        public DeleteModel(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public Sporkocu.Domain.Entities.Exercise Exercise { get; set; }

        public IActionResult OnGet(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _exerciseService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            Exercise = response.Entity;

            return Page();
        }

        public IActionResult OnPost(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _exerciseService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _exerciseService.Delete(
                new ExerciseRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage(
                "/Exercise/List",
                new { mode = "admin" });
        }
    }
}