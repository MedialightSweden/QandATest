using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QandATest.DomainEntities
{
    [Table("Application", Schema = "dbo")]
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "Please enter user!")]
        [MaxLength(450)]
        public string UserId { get; set; }

        [Display(Name = "Advertisement")]
        [Required(ErrorMessage = "Please enter Advertisement!")]
        [ForeignKey("Advertisement")]
        public int AdId { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "Please enter user email!")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256, ErrorMessage = "Email address cannot exceed more than 256 character!")]
        public string UserEmail { get; set; }

        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Please enter answer!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Answer { get; set; }

        public Advertisement Advertisement { get; set; }
    }
}
