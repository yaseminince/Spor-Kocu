using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.ScheduleLesson
{
    public class UpdateModel : PageModel
    {
        private readonly IScheduleLessonService _scheduleLessonService;

        public UpdateModel(IScheduleLessonService scheduleLessonService)
        {
            _scheduleLessonService = scheduleLessonService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.ScheduleLesson ScheduleLesson { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            var response = _scheduleLessonService.GetById(id);

            if (response.Entity == null ||
                response.Entity.UserId != userId.Value)
            {
                return RedirectToPage("/ScheduleLesson/List");
            }

            ScheduleLesson = response.Entity;

            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            var existingResponse =
                _scheduleLessonService.GetById(ScheduleLesson.Id);

            if (existingResponse.Entity == null ||
                existingResponse.Entity.UserId != userId.Value)
            {
                return RedirectToPage("/ScheduleLesson/List");
            }

            ModelState.Remove("ScheduleLesson.UserId");

            if (!ModelState.IsValid)
                return Page();

            // UserId'yi formdan gelen değere bırakmıyoruz.
            ScheduleLesson.UserId = userId.Value;

            var response = _scheduleLessonService.Update(
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