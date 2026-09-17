using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Category Category { get; set; }

        public IActionResult OnGet(string mode)
        {
            if (mode != "admin")
                return Forbid();

            Category = new Sporkocu.Domain.Entities.Category();

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _categoryService.Add(
                new CategoryRequest
                {
                    Entity = Category
                });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return RedirectToPage(
                "/Category/List",
                new { mode = "admin" });
        }
    }
}