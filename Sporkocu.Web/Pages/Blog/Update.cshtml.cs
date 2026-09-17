using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Blog
{
    public class UpdateModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public UpdateModel(
            IBlogService blogService,
            ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Blog Blog { get; set; } = new();

        public List<Sporkocu.Domain.Entities.Category> Categories { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var response = _blogService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            Blog = response.Entity;

            LoadCategories();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            // Formdan gelmesi gerekmeyen navigation property'nin
            // validation'a takılmasını engelliyoruz.
            ModelState.Remove("Blog.Category");

            LoadCategories();

            if (!ModelState.IsValid)
                return Page();

            var existingResponse = _blogService.GetById(Blog.Id);

            if (existingResponse.Error.HasException)
                return BadRequest(existingResponse.Error.Message);

            if (existingResponse.Entity == null)
                return NotFound();

            var existingBlog = existingResponse.Entity;

            existingBlog.Title = Blog.Title;
            existingBlog.SubTitle = Blog.SubTitle;
            existingBlog.HtmlContent = Blog.HtmlContent;
            existingBlog.CoverImagePath = Blog.CoverImagePath;
            existingBlog.CategoryId = Blog.CategoryId;

            var response = _blogService.Update(new BlogRequest
            {
                Entity = existingBlog
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                Blog = existingBlog;

                return Page();
            }

            return Redirect("/Blog/List?mode=admin");
        }
        private void LoadCategories()
        {
            var response = _categoryService.GetList();

            if (!response.Error.HasException &&
                response.EntityList != null)
            {
                Categories = response.EntityList;
            }
        }
    }
}