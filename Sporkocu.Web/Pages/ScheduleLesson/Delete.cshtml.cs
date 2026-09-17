using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;

namespace Sporkocu.Web.Pages.ScheduleLesson
{
    public class DeleteModel : PageModel
    {
        private readonly IScheduleLessonService _scheduleLessonService;

        public DeleteModel(IScheduleLessonService scheduleLessonService)
        {
            _scheduleLessonService = scheduleLessonService;
        }

        [BindProperty]
        public int Id { get; set; }

        public Domain.Entities.ScheduleLesson ScheduleLesson { get; set; }

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

            Id = id;
            ScheduleLesson = response.Entity;

            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            var response = _scheduleLessonService.GetById(Id);

            if (response.Entity == null ||
                response.Entity.UserId != userId.Value)
            {
                return RedirectToPage("/ScheduleLesson/List");
            }

            _scheduleLessonService.Delete(
                new ScheduleLessonRequest
                {
                    Entity = response.Entity
                });

            return RedirectToPage("/ScheduleLesson/List");
        }
    }
}