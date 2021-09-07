using System.ComponentModel.DataAnnotations;

namespace Question.DataLayer.Entities
{
    public class UserQuestion
    {
        #region properties
        [Key]
        public int Id { get; set; }

        [Display(Name = "شناسه مشارکت کننده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public short UserId { get; set; }

        [Display(Name = "شناسه سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public short QuestionId { get; set; }

        [Display(Name = "شفافیت سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Clarity { get; set; }

        [Display(Name = "تخصص در سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExtentOfExpertise { get; set; }
        #endregion

        #region relations
        public virtual User User { get; set; }
        public virtual QuestionEntity Question { get; set; }
        #endregion
    }

    public enum Clarity
    {
        VaryLow = 1 , 
        Low, 
        Medium, 
        High,
        VeryHigh
    }

    public enum ExtentOfExpertise
    {
        VeryLow = 1, 
        Low , 
        High ,
        Medium,
        Expert
    }
}
