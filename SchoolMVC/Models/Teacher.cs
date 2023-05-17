using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMVC.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; } = 0;

        [Required]
        [StringLength(30)]
        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Last name")]
        public string? LastName { get; set; }

        [NotMapped]
        [DisplayName("Teachers name")]
        public string FullName => (FirstName + " " + LastName);

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

    }
}
