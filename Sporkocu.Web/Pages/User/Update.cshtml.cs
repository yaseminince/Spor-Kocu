using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.User
{
    public class UpdateModel : PageModel
    {
        private readonly IUserService _userService;

        public UpdateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.User User { get; set; }

        public IActionResult OnGet(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _userService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            User = response.Entity;

            return Page();
        }

        public IActionResult OnPost(string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _userService.GetById(User.Id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            var existingUser = response.Entity;

            existingUser.FullName = User.FullName;
            existingUser.Email = User.Email;
            existingUser.Password = User.Password;
            existingUser.Address = User.Address;
            existingUser.PremiumPackage = User.PremiumPackage;
            existingUser.Phone = User.Phone;
            existingUser.ProfilePicPath = User.ProfilePicPath;

            var updateResponse = _userService.Update(
                new UserRequest
                {
                    Entity = existingUser
                });

            if (updateResponse.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    updateResponse.Error.Message);

                User = existingUser;

                return Page();
            }

            return RedirectToPage(
                "/User/List",
                new { mode = "admin" });
        }
    }
}