using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlan
{
    public class UpdateModel : PageModel
    {
        private readonly INutritionPlanService _nutritionPlanService;

        public UpdateModel(INutritionPlanService nutritionPlanService)
        {
            _nutritionPlanService = nutritionPlanService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.NutritionPlan NutritionPlan { get; set; }

        public IActionResult OnGet(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _nutritionPlanService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            NutritionPlan = response.Entity;

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _nutritionPlanService.GetById(
                NutritionPlan.Id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            var existingPlan = response.Entity;

            existingPlan.Title = NutritionPlan.Title;
            existingPlan.Description = NutritionPlan.Description;

            var updateResponse = _nutritionPlanService.Update(
                new NutritionPlanRequest
                {
                    Entity = existingPlan
                });

            if (updateResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    updateResponse.Error.Message);

                NutritionPlan = existingPlan;

                return Page();
            }

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }
    }
}