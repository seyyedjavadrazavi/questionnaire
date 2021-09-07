using Microsoft.EntityFrameworkCore;
using Question.Core.Services.Interfaces;
using Question.DataLayer.Context;
using Question.DataLayer.DTO.Questions;
using Question.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question.Core.Services.Implement
{
    public class QuestionService : IQuestionService
    {
        #region Costructor Config
        private readonly DataLayerContext _context;
        public QuestionService(DataLayerContext context)
        {
            _context = context;
        }
        #endregion

        public async Task CreateQuestion(CreateQuestionDTO dTO)
        {
            QuestionEntity question = new QuestionEntity()
            {
                QuStackId = dTO.QuStackId,
                Title = dTO.Title,
                Body = dTO.Body,
                Tags = dTO.Tags
            };
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task EditQuestion(QuestionEntity model , short id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(x=> x.Id == id);

            if (question == null) throw null;

            question.Body = model.Body;
            question.Title = model.Title;
            question.Tags = model.Tags;

            await _context.SaveChangesAsync();
        }

        public async Task<List<QuestionEntity>> GetAllQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<List<QuestionEntity>> GetRandomQuestion()
        {
            List<QuestionEntity> AllQuestions = await _context.Questions.ToListAsync();
            List<UserQuestion> All_User_Questions = await _context.UserQuestions.ToListAsync();

            List<QuestionEntity> RandomQuestions = new List<QuestionEntity>();

            //List<short> questionsId = new List<short>();

            var questionsId = (from user_qu in All_User_Questions
                               group user_qu.QuestionId by user_qu.QuestionId into groupTest
                               where groupTest.Count() >= 3
                               orderby groupTest.Key
                               select groupTest.Key).ToList(); //questionsId hayee ke count > 3 darand.

            Random rnd = new Random();

            int counter = 0;

            List<short> listId = new List<short>();

            while (RandomQuestions.Count() < 20 && counter < AllQuestions.Count() * 2)
            {
                int index = rnd.Next(AllQuestions.Count);
                int selected_index = AllQuestions[index].Id;
                if (!questionsId.Any(s => s == selected_index) && !listId.Any(a => a == selected_index))
                {
                    RandomQuestions.Add(AllQuestions[index]);
                    listId.Add(AllQuestions[index].Id);
                }
                counter++;
            }

            return RandomQuestions;
        }

        public async Task<QuestionEntity> GetQuestionById(short id)
        {
            return await _context.Questions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteQuestion(short id)
        {
            var model = await _context.Questions.FindAsync(id);

            if (model == null) throw null;

            _context.Questions.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task EditQuestionForApi(EditQuestionDTO dTO , short id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(x => x.Id == id);

            if (question == null) throw null;

            question.Body = dTO.Body;
            question.Title = dTO.Title;
            question.Tags = dTO.Tags;

            await _context.SaveChangesAsync();
        }

    }
}
