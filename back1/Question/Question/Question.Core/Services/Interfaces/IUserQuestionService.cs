using Question.DataLayer.DTO.UserQuestions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question.Core.Services.Interfaces
{
    public interface IUserQuestionService
    {
        Task AnswerToQuestions(SubmitExamDTO dTO);
    }
}
