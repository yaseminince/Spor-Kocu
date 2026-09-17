using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Category
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Category Category { get; set; }

        public IActionResult OnGet(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _categoryService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            Category = response.Entity;

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _categoryService.GetById(Category.Id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            var existingCategory = response.Entity;

            existingCategory.Title = Category.Title;
            existingCategory.Description = Category.Description;

            var updateResponse = _categoryService.Update(
                new CategoryRequest
                {
                    Entity = existingCategory
                });

            if (updateResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    updateResponse.Error.Message);

                Category = existingCategory;

                return Page();
            }

            return RedirectToPage(
                "/Category/List",
                new { mode = "admin" });
        }
    }
}