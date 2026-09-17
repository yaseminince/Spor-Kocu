using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string PasswordAgain { get; set; }

        [BindProperty]
        public string ProfilePicPath { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            // Varsayılan avatar
            ProfilePicPath = "/images/avatars/avatar-sandy.jpg";

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Phone) ||
                string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(PasswordAgain))
            {
                ErrorMessage = "Lütfen tüm alanları doldurunuz.";
                return Page();
            }

            if (Password != PasswordAgain)
            {
                ErrorMessage = "Şifreler eşleşmiyor.";
                return Page();
            }

            var usersResponse = _userService.GetList();

            if (usersResponse.Error.HasException)
            {
                ErrorMessage = usersResponse.Error.Message;
                return Page();
            }

            var existingUser = usersResponse.EntityList
                .FirstOrDefault(x =>
                    x.Email.Equals(
                        Email,
                        StringComparison.OrdinalIgnoreCase));

            if (existingUser != null)
            {
                ErrorMessage = "Bu email adresi zaten kayıtlı.";
                return Page();
            }

            if (string.IsNullOrWhiteSpace(ProfilePicPath))
            {
                ProfilePicPath = "/images/avatars/avatar-sandy.jpg";
            }

            var user = new Sporkocu.Domain.Entities.User
            {
                FullName = FullName,
                Email = Email,
                Phone = Phone,
                Address = Address,
                Password = Password,
                PremiumPackage = 0,
                ProfilePicPath = ProfilePicPath
            };

            var response = _userService.Add(new UserRequest
            {
                Entity = user
            });

            if (response.Error.HasException)
            {
                ErrorMessage = response.Error.Message;
                return Page();
            }

            return RedirectToPage("/Login/Index");
        }
    }
}