using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Exercise
{
    public class CreateModel : PageModel
    {
        private readonly IExerciseService _exerciseService;
        private readonly ICategoryService _categoryService;

        public CreateModel(
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

        public IActionResult OnGet(string mode)
        {
            if (mode != "admin")
                return Forbid();

            LoadCategories();

            Exercise = new Sporkocu.Domain.Entities.Exercise();

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _exerciseService.Add(
                new ExerciseRequest
                {
                    Entity = Exercise
                });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

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