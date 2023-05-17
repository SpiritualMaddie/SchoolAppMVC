using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolMVC.Models
{
    public class CourseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseListId { get; set; }

        [ForeignKey("Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course? Courses { get; set; }

        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student? Students { get; set; }

        [ForeignKey("Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher? Teachers { get; set; }
    }
}
