using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolMVC.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } = 0;

        [Required]
        [StringLength(30)]
        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Last name")]
        public string? LastName { get; set; }

        [NotMapped]
        [DisplayName("Students name")]
        public string FullName => (FirstName + " " + LastName);

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }
    }
}
