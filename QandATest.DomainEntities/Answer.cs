using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QandATest.DomainEntities
{
    [Table("Answer", Schema = "dbo")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Questionnaire")]
        public int QuestionnaireId { get; set; }

        [Required]
        [ForeignKey("AnswerType")]
        public int AnswerTypeId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string AnswerText { get; set; }

        public int NextQuestion { get; set; }

        public Questionnaire Questionnaire { get; set; }

        public AnswerType AnswerType { get; set; }

    }
}
