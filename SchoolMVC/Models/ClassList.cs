using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolMVC.Models
{
    public class ClassList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassListId { get; set; }

        [ForeignKey("SchoolClasses")]
        public int FK_ClassId { get; set; }
        public virtual SchoolClass? SchoolClasses { get; set; }

        [ForeignKey("Students")]
        public int FK_StudentId { get; set; }
        public virtual Student? Students { get; set; }

        [ForeignKey("Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher? Teachers { get; set; }
    }
}
