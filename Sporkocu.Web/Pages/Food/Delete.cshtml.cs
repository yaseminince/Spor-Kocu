using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Food
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodService _foodService;

        public DeleteModel(IFoodService foodService)
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

        public IActionResult OnPost(int id)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var response = _foodService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _foodService.Delete(new FoodRequest
            {
                Entity = response.Entity
            });

            return Redirect("/Food/List?mode=admin");
        }
    }
}