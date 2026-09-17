using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlan
{
    public class ListModel : PageModel
    {
        private readonly INutritionPlanService _nutritionPlanService;
        private readonly INutritionPlanDetailService _nutritionPlanDetailService;
        private readonly IFoodService _foodService;

        public ListModel(
            INutritionPlanService nutritionPlanService,
            INutritionPlanDetailService nutritionPlanDetailService,
            IFoodService foodService)
        {
            _nutritionPlanService = nutritionPlanService;
            _nutritionPlanDetailService = nutritionPlanDetailService;
            _foodService = foodService;
        }

        public List<Sporkocu.Domain.Entities.NutritionPlan> NutritionPlans { get; set; }
            = new List<Sporkocu.Domain.Entities.NutritionPlan>();

        public List<Sporkocu.Domain.Entities.NutritionPlanDetail> Details { get; set; }
            = new List<Sporkocu.Domain.Entities.NutritionPlanDetail>();

        public List<Sporkocu.Domain.Entities.Food> Foods { get; set; }
            = new List<Sporkocu.Domain.Entities.Food>();

        public bool IsAdmin { get; set; }

        public IActionResult OnGet()
        {
            IsAdmin = Request.Query["mode"] == "admin";

            var userId = HttpContext.Session.GetInt32("UserId");

            if (!IsAdmin && userId == null)
                return RedirectToPage("/Login/Index");

            var planResponse = _nutritionPlanService.GetList();

            if (planResponse.Error.HasException)
                return BadRequest(planResponse.Error.Message);

            NutritionPlans = planResponse.EntityList;

            var detailResponse = _nutritionPlanDetailService.GetList();

            if (detailResponse.Error.HasException)
                return BadRequest(detailResponse.Error.Message);

            Details = detailResponse.EntityList;

            var foodResponse = _foodService.GetList();

            if (foodResponse.Error.HasException)
                return BadRequest(foodResponse.Error.Message);

            Foods = foodResponse.EntityList;

            return Page();
        }
    }
}