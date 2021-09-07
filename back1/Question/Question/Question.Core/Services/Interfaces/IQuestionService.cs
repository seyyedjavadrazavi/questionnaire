using Question.DataLayer.DTO.Questions;
using Question.DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question.Core.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionEntity>> GetAllQuestions();

        Task<List<QuestionEntity>> GetRandomQuestion();
        Task<QuestionEntity> GetQuestionById(short id);
        Task CreateQuestion(CreateQuestionDTO dTO);
        Task EditQuestion(QuestionEntity model , short id);
        Task EditQuestionForApi(EditQuestionDTO dTO, short id);
        Task DeleteQuestion(short id);
    }
}
