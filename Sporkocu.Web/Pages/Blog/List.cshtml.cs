using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Blog
{
    public class ListModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public ListModel(
            IBlogService blogService,
            ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public List<Sporkocu.Domain.Entities.Blog> Blogs { get; set; } = new();

        public List<Sporkocu.Domain.Entities.Category> Categories { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Mode { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedCategoryId { get; set; }

        public bool IsAdmin => Mode == "admin";

        public IActionResult OnGet()
        {
            var blogResponse = _blogService.GetList();

            if (blogResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    blogResponse.Error.Message);

                return Page();
            }

            Blogs = blogResponse.EntityList;

            var categoryResponse = _categoryService.GetList();

            if (categoryResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    categoryResponse.Error.Message);

                return Page();
            }

            Categories = categoryResponse.EntityList;

            // Kategori seçildiyse sadece o kategorideki blogları göster
            if (SelectedCategoryId.HasValue)
            {
                Blogs = Blogs
                    .Where(x => x.CategoryId == SelectedCategoryId.Value)
                    .ToList();
            }

            return Page();
        }
    }
}