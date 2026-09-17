using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sporkocu.Web.Pages.ScheduleLesson
{
    public class ListModel : PageModel
    {
        private readonly IScheduleLessonService _scheduleLessonService;

        public ListModel(IScheduleLessonService scheduleLessonService)
        {
            _scheduleLessonService = scheduleLessonService;
        }

        public List<Sporkocu.Domain.Entities.ScheduleLesson> ScheduleLessons { get; set; } = new();

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToPage("/Login/Index");

            var response = _scheduleLessonService.GetList();

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                return Page();
            }

            ScheduleLessons = response.EntityList
                .Where(x => x.UserId == userId.Value)
                .OrderBy(x => x.StartTime)
                .ToList();

            return Page();
        }
    }
}