using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Category
{
    public class ListModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public ListModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Sporkocu.Domain.Entities.Category> Categories { get; set; }
            = new List<Sporkocu.Domain.Entities.Category>();

        public IActionResult OnGet(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _categoryService.GetList();

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            Categories = response.EntityList;

            return Page();
        }
    }
}