using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Exercise
{
    public class UpdateModel : PageModel
    {
        private readonly IExerciseService _exerciseService;
        private readonly ICategoryService _categoryService;

        public UpdateModel(
            IExerciseService exerciseService,
            ICategoryService categoryService)
        {
            _exerciseService = exerciseService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Exercise Exercise { get; set; }

        public List<Sporkocu.Domain.Entities.Category> Categories { get; set; }
            = new List<Sporkocu.Domain.Entities.Category>();

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

            LoadCategories();

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _exerciseService.GetById(Exercise.Id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            var existingExercise = response.Entity;

            existingExercise.Title = Exercise.Title;
            existingExercise.Description = Exercise.Description;
            existingExercise.ImagePath = Exercise.ImagePath;
            existingExercise.VideoLinkPath = Exercise.VideoLinkPath;
            existingExercise.CategoryId = Exercise.CategoryId;

            var updateResponse = _exerciseService.Update(
                new ExerciseRequest
                {
                    Entity = existingExercise
                });

            if (updateResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    updateResponse.Error.Message);

                Exercise = existingExercise;

                LoadCategories();

                return Page();
            }

            return RedirectToPage(
                "/Exercise/List",
                new { mode = "admin" });
        }

        private void LoadCategories()
        {
            var response = _categoryService.GetList();

            if (!response.Error.HasException)
                Categories = response.EntityList;
        }
    }
}