using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolMVC.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Course name")]
        public string? CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
