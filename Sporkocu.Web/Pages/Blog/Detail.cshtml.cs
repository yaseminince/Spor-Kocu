using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Blog
{
    public class DetailModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public DetailModel(
            IBlogService blogService,
            ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public Sporkocu.Domain.Entities.Blog Blog { get; set; }

        public Sporkocu.Domain.Entities.Category Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Mode { get; set; }

        public bool IsAdmin => Mode == "admin";

        public IActionResult OnGet(int id)
        {
            var response = _blogService.GetById(id);

            if (response.Error.HasException ||
                response.Entity == null)
            {
                return NotFound();
            }

            Blog = response.Entity;

            var categoryResponse =
                _categoryService.GetById(Blog.CategoryId);

            if (!categoryResponse.Error.HasException)
            {
                Category = categoryResponse.Entity;
            }

            return Page();
        }
    }
}