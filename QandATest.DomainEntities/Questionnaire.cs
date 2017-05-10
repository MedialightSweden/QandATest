using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("Questionnaire", Schema = "dbo")]
    public class Questionnaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Order")]
        [Required]
        public Int16 Order { get; set; }

        [Display(Name = "Advertisement")]
        [ForeignKey("Advertisement")]
        [Required(ErrorMessage = "Please enter advertisement!")]
        public int AdId { get; set; }

        [Display(Name = "Question")]
        [ForeignKey("Question")]
        [Required(ErrorMessage = "Please enter Question!")]
        public int QuestionId { get; set; }

        public Advertisement Advertisement { get; set; }

        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; } 
    }
}
