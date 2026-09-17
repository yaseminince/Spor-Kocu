using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.ScheduleLesson
{
    public class CreateModel : PageModel
    {
        private readonly IScheduleLessonService _scheduleLessonService;

        public CreateModel(IScheduleLessonService scheduleLessonService)
        {
            _scheduleLessonService = scheduleLessonService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.ScheduleLesson ScheduleLesson { get; set; } = new();

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            ScheduleLesson.StartTime = DateTime.Today;

            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            ModelState.Remove("ScheduleLesson.UserId");

            if (!ModelState.IsValid)
                return Page();

            ScheduleLesson.UserId = userId.Value;

            var response = _scheduleLessonService.Add(
                new ScheduleLessonRequest
                {
                    Entity = ScheduleLesson
                });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            return RedirectToPage("/ScheduleLesson/List");
        }
    }
}