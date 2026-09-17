using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

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

        public IActionResult OnPost(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _categoryService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _categoryService.Delete(
                new CategoryRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage(
                "/Category/List",
                new { mode = "admin" });
        }
    }
}