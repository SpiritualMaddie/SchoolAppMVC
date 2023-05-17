using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolMVC.Models
{
    public class SchoolClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Class")]
        public string? ClassName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
