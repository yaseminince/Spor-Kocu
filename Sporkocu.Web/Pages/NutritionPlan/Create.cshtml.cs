using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlan
{
    public class CreateModel : PageModel
    {
        private readonly INutritionPlanService _nutritionPlanService;

        public CreateModel(INutritionPlanService nutritionPlanService)
        {
            _nutritionPlanService = nutritionPlanService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.NutritionPlan NutritionPlan { get; set; }

        public IActionResult OnGet(string mode)
        {
            if (mode != "admin")
                return Forbid();

            NutritionPlan =
                new Sporkocu.Domain.Entities.NutritionPlan();

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            ModelState.Remove("NutritionPlan.NutritionPlans");

            if (!ModelState.IsValid)
                return Page();

            var response = _nutritionPlanService.Add(
                new NutritionPlanRequest
                {
                    Entity = NutritionPlan
                });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }
    }
}