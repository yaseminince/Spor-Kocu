using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.NutritionPlanDetail
{
    public class UpdateModel : PageModel
    {
        private readonly INutritionPlanDetailService _detailService;
        private readonly IFoodService _foodService;

        public UpdateModel(
            INutritionPlanDetailService detailService,
            IFoodService foodService)
        {
            _detailService = detailService;
            _foodService = foodService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.NutritionPlanDetail Detail { get; set; }

        public List<Sporkocu.Domain.Entities.Food> Foods { get; set; }
            = new List<Sporkocu.Domain.Entities.Food>();

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

            LoadFoods();

            return Page();
        }

        public IActionResult OnPost(string mode)
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

            var response = _detailService.GetById(Detail.Id);

            if (response.Entity == null)
            {
                return NotFound();
            }

            var existingDetail = response.Entity;

            existingDetail.NutritionPlanId = Detail.NutritionPlanId;
            existingDetail.FoodId = Detail.FoodId;
            existingDetail.Meal = Detail.Meal;

            var updateResponse = _detailService.Update(
                new NutritionPlanDetailRequest
                {
                    Entity = existingDetail
                });

            if (updateResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    updateResponse.Error.Message);

                Detail = existingDetail;
                LoadFoods();

                return Page();
            }

            return RedirectToPage(
                "/NutritionPlan/List",
                new { mode = "admin" });
        }

        private void LoadFoods()
        {
            var response = _foodService.GetList();

            if (!response.Error.HasException)
            {
                Foods = response.EntityList;
            }
        }
    }
}