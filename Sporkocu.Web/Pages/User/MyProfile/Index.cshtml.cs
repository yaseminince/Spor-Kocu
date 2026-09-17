using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.User.MyProfile
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.User User { get; set; }

        [BindProperty]
        public string? CurrentPassword { get; set; }

        [BindProperty]
        public string? NewPassword { get; set; }

        [BindProperty]
        public string? NewPasswordAgain { get; set; }


        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login/Index");
            }

            var response = _userService.GetById(userId.Value);

            if (response.Error.HasException)
            {
                return BadRequest(response.Error.Message);
            }

            if (response.Entity == null)
            {
                return NotFound();
            }

            User = response.Entity;

            return Page();
        }


        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login/Index");
            }

            var currentUserResponse =
                _userService.GetById(userId.Value);

            if (currentUserResponse.Error.HasException)
            {
                return BadRequest(
                    currentUserResponse.Error.Message);
            }

            if (currentUserResponse.Entity == null)
            {
                return NotFound();
            }

            var currentUser = currentUserResponse.Entity;


            User.Password = currentUser.Password;

            if (string.IsNullOrWhiteSpace(User.Address))
            {
                User.Address = currentUser.Address;
            }

            if (string.IsNullOrWhiteSpace(User.ProfilePicPath))
            {
                User.ProfilePicPath =
                    currentUser.ProfilePicPath;
            }


            ModelState.Remove("User.Password");
            ModelState.Remove("User.Address");
            ModelState.Remove("User.ProfilePicPath");

            currentUser.FullName = User.FullName;
            currentUser.Email = User.Email;
            currentUser.Phone = User.Phone;
            currentUser.Address = User.Address;
            currentUser.ProfilePicPath = User.ProfilePicPath;


            // şifre değişikliği

            if (!string.IsNullOrWhiteSpace(CurrentPassword) ||
                !string.IsNullOrWhiteSpace(NewPassword) ||
                !string.IsNullOrWhiteSpace(NewPasswordAgain))
            {

                if (string.IsNullOrWhiteSpace(CurrentPassword))
                {
                    ModelState.AddModelError(
                        "CurrentPassword",
                        "Mevcut şifrenizi giriniz.");

                    User = currentUser;

                    return Page();
                }


                if (CurrentPassword != currentUser.Password)
                {
                    ModelState.AddModelError(
                        "CurrentPassword",
                        "Mevcut şifreniz hatalı.");

                    User = currentUser;

                    return Page();
                }


                if (string.IsNullOrWhiteSpace(NewPassword))
                {
                    ModelState.AddModelError(
                        "NewPassword",
                        "Yeni şifrenizi giriniz.");

                    User = currentUser;

                    return Page();
                }


                if (string.IsNullOrWhiteSpace(NewPasswordAgain))
                {
                    ModelState.AddModelError(
                        "NewPasswordAgain",
                        "Yeni şifrenizi tekrar giriniz.");

                    User = currentUser;

                    return Page();
                }

                if (NewPassword != NewPasswordAgain)
                {
                    ModelState.AddModelError(
                        "NewPasswordAgain",
                        "Yeni şifreler eşleşmiyor.");

                    User = currentUser;

                    return Page();
                }

                currentUser.Password = NewPassword;
            }

            var response = _userService.Update(
                new UserRequest
                {
                    Entity = currentUser
                });


            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                User = currentUser;

                return Page();
            }

            User = response.Entity;

            CurrentPassword = null;
            NewPassword = null;
            NewPasswordAgain = null;


            ViewData["SuccessMessage"] =
                "Profil bilgileriniz başarıyla güncellendi.";


            return Page();
        }
    }
}