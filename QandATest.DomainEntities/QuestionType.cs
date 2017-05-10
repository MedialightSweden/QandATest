using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("QuestionType", Schema ="dbo")]
    public class QuestionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Question type title")]
        [Required(ErrorMessage = "Please enter question type title!")]
        [MaxLength(50, ErrorMessage = "Question type title cannot exceed more than 50 character!")]
        public string QTypeTitle { get; set; }
    }
}
