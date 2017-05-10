using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("Duty", Schema = "dbo")]
    public class Duty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Duty title")]
        [Required(ErrorMessage = "Please enter duty title!")]
        [MaxLength(500, ErrorMessage = "Duty cannot exceed more than 500 characters!")]
        public string DutyTitle { get; set; }
        
        [Display(Name = "Advertisement")]
        [Required(ErrorMessage = "Please enter advertisement!")]
        [ForeignKey("Ad")]
        public int AdId { get; set; }

        public Advertisement Ad { get; set; }
    }
}
