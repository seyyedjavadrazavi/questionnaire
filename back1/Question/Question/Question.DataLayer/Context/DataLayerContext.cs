using Microsoft.EntityFrameworkCore;
using Question.DataLayer.Entities;

namespace Question.DataLayer.Context
{
    public class DataLayerContext : DbContext
    {
        public DataLayerContext(DbContextOptions options) : base(options)
        {

        }

        #region DataBase Set
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        #endregion
    }
}
