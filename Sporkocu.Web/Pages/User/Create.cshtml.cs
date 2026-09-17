using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _service;

        public CreateModel(IUserService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserRequest Request { get; set; }

        public IActionResult OnGet(string mode)
        {
            if (mode != "admin")
                return Forbid();

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            Request.Entity.Address = "";
            Request.Entity.Phone = "";
            Request.Entity.ProfilePicPath = "";
            Request.Entity.CreatedBy = 1;
            Request.Entity.PremiumPackage = 1;

            var result = _service.Add(Request);

            if (result.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Error.Message);

                return Page();
            }

            return RedirectToPage(
                "/User/List",
                new { mode = "admin" });
        }
    }
}