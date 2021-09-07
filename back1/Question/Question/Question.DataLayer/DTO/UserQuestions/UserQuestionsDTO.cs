using Question.DataLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Question.DataLayer.DTO.UserQuestions
{
    public class UserQuestionsDTO
    {
        [Display(Name = "شناسه سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public short QuestionId { get; set; }
        [Display(Name = "شفافیت سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Clarity { get; set; }
        [Display(Name = "تخصص در سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExtentOfExpertise { get; set; }
    }

    public class RegisterUserDTO
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(80, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }
        [Display(Name = "ایمیل")]
        public string CodeMelli { get; set; }
    }

    public class SubmitExamDTO
    {
        public RegisterUserDTO Register { get; set; }
        public List<UserQuestionsDTO> Answers { get; set; }
    }
}
