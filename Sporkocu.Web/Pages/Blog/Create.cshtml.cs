using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public CreateModel(
            IBlogService blogService,
            ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Blog Blog { get; set; } = new();

        public List<Sporkocu.Domain.Entities.Category> Categories { get; set; } = new();

        public IActionResult OnGet()
        {
            LoadCategories();
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Blog.Category");

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return Page();
            }

            var response = _blogService.Add(new BlogRequest
            {
                Entity = Blog
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                LoadCategories();
                return Page();
            }

            return Redirect("/Blog/List?mode=admin");
        }

        private void LoadCategories()
        {
            var response = _categoryService.GetList();

            if (!response.Error.HasException)
            {
                Categories = response.EntityList;
            }
        }
    }
}