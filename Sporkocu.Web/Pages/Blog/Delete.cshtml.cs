using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogService _blogService;

        public DeleteModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Blog Blog { get; set; } = new();

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

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var response = _blogService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _blogService.Delete(new BlogRequest
            {
                Entity = response.Entity
            });

            return Redirect("/Blog/List?mode=admin");
        }
    }
}