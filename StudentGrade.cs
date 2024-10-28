using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class StudentGrade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; } // Foreign key reference to Student table

        [Required]
        public string? Name { get; set; } // This will be fetched from Student model

        [Required]
        public string? Branch { get; set; } // This will be fetched from Student model

        [Required]
        public string? Semester { get; set; } // This will be fetched from Student model

        // Navigation Property for SubjectGrades
        public List<SubjectGrade> SubjectGrades { get; set; } = new List<SubjectGrade>();

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

    }
}
