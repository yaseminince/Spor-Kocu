using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.Interfaces;
using Sporkocu.Domain.Entities;

namespace Sporkocu.Web.Pages.Answer
{
    public class UpdateModel : PageModel
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public UpdateModel(
            IAnswerService answerService,
            IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        [BindProperty]
        public Sporkocu.Domain.Entities.Answer Answer { get; set; } = new();

        public Sporkocu.Domain.Entities.Question Question { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            var response = _answerService.GetById(id);

            if (response.Error.HasException)
                return BadRequest(response.Error.Message);

            if (response.Entity == null)
                return NotFound();

            Answer = response.Entity;

            var questionResponse = _questionService.GetById(Answer.QuestionId);

            if (!questionResponse.Error.HasException &&
                questionResponse.Entity != null)
            {
                Question = questionResponse.Entity;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Query["mode"] != "admin")
                return RedirectToPage("/Login/Index");

            if (!ModelState.IsValid)
                return Page();

            var existingResponse = _answerService.GetById(Answer.Id);

            if (existingResponse.Error.HasException)
                return BadRequest(existingResponse.Error.Message);

            if (existingResponse.Entity == null)
                return NotFound();

            var existingAnswer = existingResponse.Entity;

            existingAnswer.Description = Answer.Description;
            existingAnswer.Step = Answer.Step;

            var response = _answerService.Update(new AnswerRequest
            {
                Entity = existingAnswer
            });

            if (response.Error.HasException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    response.Error.Message);

                Answer = existingAnswer;

                return Page();
            }

            return Redirect("/Question/List?mode=admin");
        }
    }
}