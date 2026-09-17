using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlanDetail
{
    public class ListModel : PageModel
    {
        private readonly INutritionPlanDetailService _detailService;
        private readonly IFoodService _foodService;

        public ListModel(
            INutritionPlanDetailService detailService,
            IFoodService foodService)
        {
            _detailService = detailService;
            _foodService = foodService;
        }

        public List<Sporkocu.Domain.Entities.NutritionPlanDetail> Details { get; set; }
            = new List<Sporkocu.Domain.Entities.NutritionPlanDetail>();

        public List<Sporkocu.Domain.Entities.Food> Foods { get; set; }
            = new List<Sporkocu.Domain.Entities.Food>();

        public IActionResult OnGet(string mode)
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

            var detailResponse = _detailService.GetList();

            if (detailResponse.Error.HasException)
            {
                return BadRequest(detailResponse.Error.Message);
            }

            Details = detailResponse.EntityList;

            var foodResponse = _foodService.GetList();

            if (foodResponse.Error.HasException)
            {
                return BadRequest(foodResponse.Error.Message);
            }

            Foods = foodResponse.EntityList;

            return Page();
        }
    }
}