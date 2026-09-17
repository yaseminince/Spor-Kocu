using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Food
{
    public class CreateModel : PageModel
    {
        private readonly IFoodService _foodService;

        public CreateModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Food Food { get; set; } = new();

        public IActionResult OnGet()
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            if (!ModelState.IsValid)
                return Page();

            var response = _foodService.Add(new FoodRequest
            {
                Entity = Food
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return Redirect("/Food/List?mode=admin");
        }
    }
}