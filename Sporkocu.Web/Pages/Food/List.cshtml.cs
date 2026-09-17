using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Food
{
    public class ListModel : PageModel
    {
        private readonly IFoodService _foodService;

        public ListModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public List<Sporkocu.Domain.Entities.Food> Foods { get; set; } = new();

        public bool IsAdmin => Request.Query["mode"] == "admin";

        [BindProperty(SupportsGet = true)] // search bar için supportsget= true GET için de çalışsın diye
        public string? Search { get; set; }

        public IActionResult OnGet()
        {
            if (!IsAdmin)
            {
                var userId = HttpContext.Session.GetInt32("UserId");

                if (userId == null)
                    return RedirectToPage("/Login/Index");
            }

            var response = _foodService.GetList();

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            Foods = response.EntityList
                ?? new List<Sporkocu.Domain.Entities.Food>();


            // search bar için

            if (!string.IsNullOrWhiteSpace(Search))
            {
                Foods = Foods
                    .Where(x =>
                        !string.IsNullOrWhiteSpace(x.Title) &&
                        x.Title.Contains(
                            Search.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Page();
        }
    }
}