using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class SubjectGrade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Grade { get; set; }

        // Foreign key to StudentGrade
        public int StudentGradeId { get; set; }

        [ForeignKey("StudentGradeId")]
        public StudentGrade? StudentGrade { get; set; }
    }
}
