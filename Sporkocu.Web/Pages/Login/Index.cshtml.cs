using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Email ve şifre boş bırakılamaz.";
                return Page();
            }

            var response = _userService.GetByFilter(new UserRequest
            {
                Entity = new Domain.Entities.User
                {
                    Email = Email,
                    Password = Password
                }
            });

            if (response.Error.HasException)
            {
                ErrorMessage = response.Error.Message;
                return Page();
            }

            if (response.Entity == null)
            {
                ErrorMessage = "Email veya şifre hatalı.";
                return Page();
            }

            // Database'deki gerçek User.Id
            HttpContext.Session.SetInt32(
                "UserId",
                response.Entity.Id
            );

            return RedirectToPage("/UserDashboard/Dashboard");
        }
    }
}