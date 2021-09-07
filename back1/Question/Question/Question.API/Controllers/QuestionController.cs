using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question.Core.Services.Interfaces;
using Question.DataLayer.DTO.Questions;
using Question.DataLayer.Entities;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Question.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        #region Constructor
        private readonly IQuestionService _questionServie;
        public QuestionController(IQuestionService questionServie)
        {
            _questionServie = questionServie;
        }
        #endregion

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionServie.GetAllQuestions();

            var data = result.Select(x => new
            {
                x.Id,
                x.Title,
                x.Body,
                Tags = x.Tags.Replace("<", "").Split(">").Where(y => !string.IsNullOrEmpty(y)),
            });

            if (result != null) return Ok(data);
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRandomQuestion()
        {
            var result = await _questionServie.GetRandomQuestion();

            var data = result.Select(x => new
            {
                x.Id,
                x.Title,
                x.Body,
                Tags = x.Tags.Replace("<", "").Split(">").Where(y => !string.IsNullOrEmpty(y)),
            });

            if (result != null) return Ok(data);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var result = await _questionServie.GetQuestionById(id);

            var data = new
            {
                result.Id,
                result.Title,
                result.Body,
                Tags = result.Tags.Replace("<", "").Split(">").Where(y => !string.IsNullOrEmpty(y)),
            };

            if (result != null) return Ok(result);
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDTO dTO)
        {
            try
            {
                await _questionServie.CreateQuestion(dTO);
                return Ok(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] EditQuestionDTO dTO, [FromRoute] short id)
        {
            try
            {
                await _questionServie.EditQuestionForApi(dTO, id);
                return Ok(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            try
            {
                await _questionServie.DeleteQuestion(id);
                return Ok(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }


        [HttpPut("[action]")]
        public void ReadQuestions()
        {
            using (var reader = new StreamReader(@"C:\Users\i3 6100\Desktop\ai\Posts\Posts.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }
        }
    }
}
