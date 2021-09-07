using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Question.DataLayer.Entities
{
    public class User
    {
        #region properties
        [Key]
        public short Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }
        
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(70, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CodeMelli { get; set; }
        #endregion

        #region relations
        public virtual List<UserQuestion> UserQuestions { get; set; }
        #endregion
    }
}
