using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlanDetail
{
    public class DeleteModel : PageModel
    {
        private readonly INutritionPlanDetailService _detailService;
        private readonly IFoodService _foodService;

        public DeleteModel(
            INutritionPlanDetailService detailService,
            IFoodService foodService)
        {
            _detailService = detailService;
            _foodService = foodService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.NutritionPlanDetail Detail { get; set; }

        public Sporkocu.Domain.Entities.Food Food { get; set; }

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

            var response = _detailService.GetById(id);

            if (response.Error.HasException)
            {
                return BadRequest(response.Error.Message);
            }

            if (response.Entity == null)
            {
                return NotFound();
            }

            Detail = response.Entity;

            var foodResponse = _foodService.GetById(Detail.FoodId);

            if (!foodResponse.Error.HasException)
            {
                Food = foodResponse.Entity;
            }

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

            var response = _detailService.GetById(id);

            if (response.Entity == null)
            {
                return NotFound();
            }

            _detailService.Delete(
                new NutritionPlanDetailRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }
    }
}