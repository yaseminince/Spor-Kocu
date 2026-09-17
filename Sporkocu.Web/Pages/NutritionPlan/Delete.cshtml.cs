using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlan
{
    public class DeleteModel : PageModel
    {
        private readonly INutritionPlanService _nutritionPlanService;

        public DeleteModel(INutritionPlanService nutritionPlanService)
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

        public IActionResult OnPost(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _nutritionPlanService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _nutritionPlanService.Delete(
                new NutritionPlanRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }
    }
}