using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request; // katmanlar arası veri taşımak için gerekiyor
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Admin.Login
{
    public class IndexModel : PageModel // bu sınıf razor pagein arkasındaki page modeldir
    {
        private readonly IUserService _userService;
        // page modelin çalışabilmesi için bir IUserService

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        // gidip dependency injectiondan userservicei alıyor baştan yazmak durumunda kalmıyoruz

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        // IActionResult : bu http isteğinin sonucunda ne yapacağım? demek

        public IActionResult OnPost()
        {
            if (Email != "admin@sporkocu.com" ||
                Password != "123456")
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Admin e-posta veya şifre hatalı.");

                return Page();
            }

            var response = _userService.GetByFilter(new UserRequest
            {
                Entity = new Sporkocu.Domain.Entities.User
                {
                    Email = Email,
                    Password = Password
                }
            });

            if (response.Entity == null)
            {
                var addResponse = _userService.Add(new UserRequest
                {
                    Entity = new Sporkocu.Domain.Entities.User
                    {
                        FullName = "Admin",
                        Email = Email,
                        Password = Password,
                        Address = "",
                        PremiumPackage = 0,
                        Phone = "",
                        ProfilePicPath = ""
                    }
                });

                if (addResponse.Error.HasException)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        addResponse.Error.Message);

                    return Page();
                }

                response.Entity = addResponse.Entity;
            }

            HttpContext.Session.SetInt32("UserId", response.Entity.Id);

            return RedirectToPage("/Admin/Dashboard");
        }
    }
}