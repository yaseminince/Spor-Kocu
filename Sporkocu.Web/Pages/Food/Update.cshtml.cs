using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Food
{
    public class UpdateModel : PageModel
    {
        private readonly IFoodService _foodService;

        public UpdateModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Food Food { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var response = _foodService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            Food = response.Entity;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            if (!ModelState.IsValid)
                return Page();

            var existingResponse = _foodService.GetById(Food.Id);

            if (existingResponse.Error.HasException)
                return BadRequest(existingResponse.Error.Message);

            if (existingResponse.Entity == null)
                return NotFound();

            var existingFood = existingResponse.Entity;

            existingFood.Title = Food.Title;
            existingFood.Description = Food.Description;
            existingFood.Calorie = Food.Calorie;
            existingFood.Protein = Food.Protein;
            existingFood.Carbonhydrate = Food.Carbonhydrate;
            existingFood.Oil = Food.Oil;
            existingFood.Image = Food.Image;

            var response = _foodService.Update(new FoodRequest
            {
                Entity = existingFood
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                Food = existingFood;

                return Page();
            }

            return Redirect("/Food/List?mode=admin");
        }
    }
}