using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("Question", Schema ="dbo")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Question title")]
        [Required(ErrorMessage = "Please enter question title!")]
        [MaxLength(1024, ErrorMessage = "Question title cannot exceed more than 1024 characters!")]
        public string QuestionTitle { get; set; }

        [ForeignKey("QType")]
        [Required(ErrorMessage = "Please enter question type!")]
        public int QTypeId { get; set; }

        public bool IsDependent { get; set; }

        public QuestionType QType { get; set; }
    }
}
