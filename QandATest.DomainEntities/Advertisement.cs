using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandATest.DomainEntities
{
    [Table("Advertisement", Schema = "dbo")]
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Ad Title")]
        [Required(ErrorMessage = "Please enter advertisement title!")]
        [MaxLength(500, ErrorMessage = "Ad title cannot exceed more than 500 characters!")]
        public string AdTitle { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Please enter job title!")]
        [MaxLength(50, ErrorMessage = "Job title cannot exceed more than 50 characters!")]
        public string JobTitle { get; set; }

        [Display(Name = "Employer Company Name")]
        [Required(ErrorMessage = "Please enter Employer Company Name!")]
        [MaxLength(64, ErrorMessage = "Employer Company Name cannot exceed more than 64!")]
        public string EmployerCompany { get; set; }

        [Display(Name = "Deadline")]
        [Required(ErrorMessage = "Please enter deadline date!")]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        [Display(Name = "Cooperation Type")]
        [Required(ErrorMessage = "Please enter cooperation type!")]
        [MaxLength(50, ErrorMessage = "Cooperation type cannot exceed more than 50 characters!")]
        public string CooperationType { get; set; }

        [Display(Name = "Skill description")]
        [Required(ErrorMessage = "Please enter cooperation type!")]
        //[MaxLength(4000, ErrorMessage = "Skill description cannot exceed more than 4000 characters!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string SkillDesc { get; set; }

        [Display(Name = "Job duties description")]
        [Required(ErrorMessage = "Please enter job deuties description!")]
        //[MaxLength(4000, ErrorMessage = "Duty description cannot exceed more than 4000 characters!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DutyDesc { get; set; }

        [Display(Name = "Employer description")]
        [Required(ErrorMessage = "Please enter employer description!")]
        //[MaxLength(4000, ErrorMessage = "Employer description cannot exceed more than 4000 characters!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string EmployerDescription { get; set; }

        [Display(Name = "Website")]
        [Required(ErrorMessage = "Please enter website!")]
        [MaxLength(50, ErrorMessage = "Website cannot exceed more than 50 characters!")]
        public string EmployerWebsite { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email!")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed more than 50 characters!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is invalid!")]
        public string EmployerEmail { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Please enter employer phone number!")]
        [MaxLength(50, ErrorMessage = "Phone number cannot exceed more than 50 characters!")]
        [DataType(DataType.PhoneNumber)]
        public string EmployerPhoneNumber { get; set; }

        [Display(Name = "Employer address")]
        [Required(ErrorMessage = "Please enter employer address!")]
        //[MaxLength(4000, ErrorMessage = "employer address cannot exceed more than 4000 characters!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string EmployerAddress { get; set; }
        
    }
}
