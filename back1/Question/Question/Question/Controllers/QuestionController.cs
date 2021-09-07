using Microsoft.AspNetCore.Mvc;
using Question.Core.Services.Interfaces;
using Question.DataLayer.DTO.Questions;
using Question.DataLayer.Entities;
using System.Threading.Tasks;

namespace Question.Controllers
{
    public class QuestionController : Controller
    {
        #region constructor
        private IQuestionService _questionServie;
        public QuestionController(IQuestionService questionServie)
        {
            _questionServie = questionServie;
        }
        #endregion

        [HttpGet("index-question")]
        public async Task<IActionResult> Index()
        {
            var model = await _questionServie.GetAllQuestions();
            return View(model);
        }

        [HttpGet("create-question")]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost("create-question") , ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDTO dTO)
        {
            if (ModelState.IsValid)
            {
                await _questionServie.CreateQuestion(dTO);
                return RedirectToAction(nameof(Index));
            }
            return View(dTO);
        }

        [HttpGet("edit-question/{id}")]
        public async Task<IActionResult> EditQuestion(short id)
        {
            var model = await _questionServie.GetQuestionById(id);
            return View(model);
        }

        [HttpPost("edit-question/{id}") , ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(QuestionEntity model ,short id)
        {
            if (ModelState.IsValid)
            {
                await _questionServie.EditQuestion(model , id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet("delete-question/{id}")]
        public IActionResult DeleteQuestion(short? id)
        {
            return View();
        }

        [HttpPost("delete-question/{id}") , ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuestion(short id)
        {
            if (ModelState.IsValid)
            {
                await _questionServie.DeleteQuestion(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}