using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.User
{
    public class ListModel : PageModel
    {
        private readonly IUserService _userService;

        public ListModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<Sporkocu.Domain.Entities.User> Users { get; set; }
            = new List<Sporkocu.Domain.Entities.User>();

        public bool IsAdmin { get; set; }

        public IActionResult OnGet()
        {
            IsAdmin = Request.Query["mode"] == "admin";

            var userId = HttpContext.Session.GetInt32("UserId");

            if (!IsAdmin && userId == null)
                return RedirectToPage("/Login/Index");

            var response = _userService.GetList();

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            Users = response.EntityList;

            return Page();
        }
    }
}