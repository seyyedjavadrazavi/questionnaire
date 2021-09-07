using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question.Core.Services.Interfaces;
using Question.DataLayer.DTO.UserQuestions;
using System.Threading.Tasks;

namespace Question.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurvayController : ControllerBase
    {
        #region Constructor
        private readonly IUserQuestionService _userQuestionService;
        public SurvayController(IUserQuestionService userQuestionService)
        {
            _userQuestionService = userQuestionService;
        }
        #endregion

        [HttpPost("[action]")]
        public async Task<IActionResult> Start([FromBody] SubmitExamDTO dTO)
        {
            try
            {
                await _userQuestionService.AnswerToQuestions(dTO);
                return Ok(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

    }
}

