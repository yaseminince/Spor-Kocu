using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

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

        public IActionResult OnPost(int id, string mode)
        {
            if (mode != "admin")
                return Forbid();

            var response = _userService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            _userService.Delete(
                new UserRequest
                {
                    Entity = response.Entity
                });


            return RedirectToPage(
                "/User/List",
                new { mode = "admin" });
        }
    }
}