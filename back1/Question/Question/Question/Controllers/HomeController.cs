using Microsoft.AspNetCore.Mvc;
using Question.Core.Services.Interfaces;
using Question.DataLayer.DTO.UserQuestions;
using System.Threading.Tasks;

namespace Question.Controllers
{
    public class HomeController : Controller
    {
        #region constructor
        private IUserQuestionService _userQuestionService;
        private IQuestionService _questionServie;
        public HomeController(IUserQuestionService userQuestionService , IQuestionService questionServie)
        {
            _userQuestionService = userQuestionService;
            _questionServie = questionServie;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("start-survey")]
        public async Task<IActionResult> StartSurvey() 
        {
            ViewBag.Questions = await _questionServie.GetRandomQuestion();
            return View();
        }

        [HttpPost("start-survey") , ValidateAntiForgeryToken]
        public async Task<IActionResult> StartSurvey(SubmitExamDTO dTO)
        {
            if (ModelState.IsValid)
            {
                await _userQuestionService.AnswerToQuestions(dTO);
                RedirectToAction(nameof(Success));
            }

            return View(dTO);
        }

        public IActionResult Success()
        {
            return View();
        }

    }
}
