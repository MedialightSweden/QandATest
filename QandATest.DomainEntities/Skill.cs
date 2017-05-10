using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("Skill", Schema = "dbo")]
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Skill Title")]
        [Required(ErrorMessage = "Please enter skill title!")]
        [MaxLength(500, ErrorMessage = "Skill title cannot exceed more than 500 characters!")]
        public string SkillTitle { get; set; }

        [Display(Name = "Advertisement")]
        [Required(ErrorMessage = "Please enter advertisement!")]
        [ForeignKey("Ad")]
        public int AdId { get; set; }

        public Advertisement Ad { get; set; }
    }
}
