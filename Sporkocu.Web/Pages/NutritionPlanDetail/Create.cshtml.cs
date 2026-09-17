using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlanDetail
{
    public class CreateModel : PageModel
    {
        private readonly INutritionPlanDetailService _detailService;
        private readonly IFoodService _foodService;
        private readonly INutritionPlanService _nutritionPlanService;

        public CreateModel(
            INutritionPlanDetailService detailService,
            IFoodService foodService,
            INutritionPlanService nutritionPlanService)
        {
            _detailService = detailService;
            _foodService = foodService;
            _nutritionPlanService = nutritionPlanService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.NutritionPlanDetail Detail { get; set; }
            = new();

        public List<Sporkocu.Domain.Entities.Food> Foods { get; set; }
            = new();

        public string NutritionPlanTitle { get; set; } = "";

        public IActionResult OnGet(int nutritionPlanId, string mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            if (mode != "admin")
                return Forbid();

            var planResponse = _nutritionPlanService.GetById(nutritionPlanId);

            if (planResponse.Error.HasException)
                return BadRequest(planResponse.Error.Message);

            if (planResponse.Entity == null)
                return NotFound();

            NutritionPlanTitle = planResponse.Entity.Title;

            var foodResponse = _foodService.GetList();

            if (foodResponse.Error.HasException)
                return BadRequest(foodResponse.Error.Message);

            Foods = foodResponse.EntityList;

            Detail = new Sporkocu.Domain.Entities.NutritionPlanDetail
            {
                NutritionPlanId = nutritionPlanId
            };

            return Page();
        }

        public IActionResult OnPost(int nutritionPlanId, string mode)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            if (mode != "admin")
                return Forbid();

            // Navigation property formdan gelmiyor.
            ModelState.Remove("Detail.NutritionPlan");

            // Hangi plana öğün eklediğimizi URL'deki ID'den alıyoruz.
            Detail.NutritionPlanId = nutritionPlanId;

            if (!ModelState.IsValid)
            {
                LoadPageData(nutritionPlanId);
                return Page();
            }

            var response = _detailService.Add(
                new NutritionPlanDetailRequest
                {
                    Entity = Detail
                });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                LoadPageData(nutritionPlanId);
                return Page();
            }

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }

        private void LoadPageData(int nutritionPlanId)
        {
            var planResponse = _nutritionPlanService.GetById(nutritionPlanId);

            if (!planResponse.Error.HasException &&
                planResponse.Entity != null)
            {
                NutritionPlanTitle = planResponse.Entity.Title;
            }

            var foodResponse = _foodService.GetList();

            if (!foodResponse.Error.HasException)
            {
                Foods = foodResponse.EntityList;
            }
        }
    }
}