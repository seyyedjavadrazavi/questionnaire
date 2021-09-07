using Question.Core.Services.Interfaces;
using Question.DataLayer.Context;
using Question.DataLayer.DTO.UserQuestions;
using Question.DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question.Core.Services.Implement
{
    public class UserQuestionsService : IUserQuestionService
    {
        #region Costructor Config
        private readonly DataLayerContext _context;
        public UserQuestionsService(DataLayerContext context)
        {
            _context = context;
        }
        #endregion

        public async Task AnswerToQuestions(SubmitExamDTO dTO)
        {

            User newUser = new User()
            {
                FullName = dTO.Register.FullName,
                CodeMelli = dTO.Register.CodeMelli
            };

            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();

            foreach(var answer in dTO.Answers)
            {
                UserQuestion userQuestion = new UserQuestion()
                {
                    UserId = newUser.Id,
                    QuestionId = answer.QuestionId,
                    Clarity = answer.Clarity,
                    ExtentOfExpertise = answer.ExtentOfExpertise
                };

                await _context.UserQuestions.AddAsync(userQuestion);
            }

            await _context.SaveChangesAsync();
        }
    }
}
